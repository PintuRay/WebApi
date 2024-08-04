var app = angular.module('templating_app');
app.service("SignUpSvc", function ($http, apiUrl) {
    this.validateToken = function (regToken) {
        var response = $http({
            method: "get",
            url: apiUrl + "SignUp/ValidateToken?Token=" + regToken,
            headers: {
                'Content-Type': 'application/json'
            }
        })
        return response;
    }
    this.isEmailInUse = function (mail) {
        var response = $http({
            method: "get",
            url: apiUrl + "SignUp/IsEmailInUse?email=" + mail,
            headers: {
                'Content-Type': 'application/json'
            }
        })
        return response;
    }
    this.signUp = function (user) {
        var response = $http({
            method: "post",
            url: apiUrl + "SignUp/SignUp",
            data: JSON.stringify(user),
            headers: {
                'Content-Type': 'application/json'
            }
        })
        return response;
    }
})
app.controller('SignUpCtrl', function ($scope, $routeParams, $location, LocalStorageService, SignUpSvc) {
    /*----------------Variable Declaration----------------------*/
    $scope.formDisabled = true;
    /*----------------Validation and Input -------------------- */
    $(function () {
        $('[data-toggle="input-mask"]').each(function (a, e) {
            var t = $(e).data("maskFormat"),
                n = $(e).data("reverse");
            null != n ? $(e).mask(t, {
                reverse: n
            }) : $(e).mask(t)
        })
    });
    $scope.validateForm = function (event, index, value) {
        switch (index) {
            case '0':
                if (value) {
                    let regex = /^[a-zA-Z]+$/;
                    if (regex.test(value)) {
                        $scope.firstname = value.toUpperCase();
                    }
                    else {
                        $scope.firstname = value.slice(0, -1);
                    }
                }
                break;
            case '1':
                if (value) {
                    let regex = /^[a-zA-Z]+$/;
                    if (regex.test(value)) {
                        $scope.lastname = value.toUpperCase();
                    }
                    else {
                        $scope.lastname = value.slice(0, -1);
                    }
                }
                break;
            case '2':
                if (value) {
                    let regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
                    if (regex.test(value)) {
                        let result = SignUpSvc.isEmailInUse(value);
                        result.then(function (response, status, headers, config) {
                            let obj = response.data;
                            if (obj.responseCode === 200) {
                                toastr.warning('Email Alredy inUse')
                            }
                        });
                    }
                    else {
                        toastr.error("Invalid Mail Format")
                    }
                }
                break;
            case '3':
                if (value) {
                    let regex = /^\d{1,10}$/;
                    if (!regex.test(value)) {
                        $scope.phoneno = value.slice(0, -1);
                    }
                }
                break;
            case '4':
                if (value) {
                    let regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$/;
                    if (!regex.test(value)) {
                        toastr.error("Password must contain:<br>&#8226; <b>At least one lowercase letter [a-z].</b><br>&#8226;<b>At least one uppercase letter.[A-Z]</b><br>&#8226;<b>At least one digit.<b><br>&#8226;<b>Min Length Should be 8 <b>");
                    }
                }
                break;
            default:
        }
    };
    /*-------------------- Functions--------------------------*/
    $scope.validateToken = function () {
        if ($scope.regtoken) {
            let regex = /^[0-9]{3}-[0-9]{3}-[0-9]{4}$/;
            if (regex.test($scope.regtoken)) {
                let result = SignUpSvc.validateToken($scope.regtoken);
                result.then(function (response, status, headers, config) {
                    let obj = response.data;
                    if (obj.responseCode === 200) {
                        $scope.formDisabled = false;
                        $scope.tokenId = obj.data.tokenId;
                    }
                }).catch((error) => {
                    toastr.error(error.data.message);
                });
            }
        }
        else {
            toastr.warning('register token is Empty');
        }
    }
    $scope.signup = function () {
        var user = {
            FkTokenId: $scope.tokenId,
            Name: $scope.firstname + ' ' + $scope.lastname,
            Email: $scope.email,
            PhoneNumber: $scope.phoneno,
            Password: $scope.password,
            ConformPassword: $scope.repeatpassword,
        }
        var result = SignUpSvc.signUp(user);
        result.then(function (response, status, headers, config) {
            let obj = response.data;
            if (obj.responseCode === 201) {
                $location.path('/sendConformationMail').search('message', obj.message);
            }
        }).catch((error) => {
            toastr.error();
        });
    }
    /*-------------------------------------------------------- */
    function clearform() {
        $scope.firstname = '';
        $scope.lastname = '';
        $scope.email = '';
        $scope.phoneno = '';
        $scope.password = '';
        $scope.repeatpassword = '';
    }

})