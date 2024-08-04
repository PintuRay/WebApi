var app = angular.module('templating_app');
app.service("LoginSvc", function ($http, apiUrl) {
    this.Login = function (user) {
        var response = $http({
            method: "post",
            url: apiUrl + "SignIn/Login",
            data: JSON.stringify(user),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        return response;
    }
})
app.controller('LoginCtrl', function ($scope, $routeParams, $location, LocalStorageService, LoginSvc) {
    $scope.login = function () {
        var username = $scope.username;
        var password = $scope.password;
        var rememberme = $scope.rememberme;
        if (username == undefined || username == "") {
            return;
        }
        else if (password == undefined || password == "") {
            return;
        }
        else {
            var user = {
                Email: username,
                Password: password,
            }
            var login_user = LoginSvc.Login(user);
            login_user.then(function (response, status, headers, config) {
                let obj = response.data;
                if (obj.responseCode == 200) {
                    if (obj.data.twoFactorEnable) {
                        $location.path('/twoFactorLogin/' + user.Email);
                    }
                    else {
                        LocalStorageService.setToken(obj.data.jwtToken);
                        LocalStorageService.setUserMail(user.Email);
                        $location.path('/dashboard');
                    }
                }
            }).catch((error) => {
                let obj = error.data;
                if (obj.responseCode == 405) {
                    $location.path('/sendConformationMail').search('message', obj.message);
                }
                if (obj.responseCode == 400) {
                    toastr.error(obj.message);
                } 
            });
        }
    };
})
