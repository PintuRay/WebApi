var app = angular.module('templating_app');
app.service("VerifyConfirmMailSvc", function ($http, apiUrl) {
    this.verifyConfirmEmail = function (uid ,token) {
        var response = $http({
            method: "get",
            url: apiUrl + 'SignUp/VerifyConfirmEmail?uid=' + uid + '&&token=' + token +'',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        return response;
    }
})
app.controller('VerifyConfirmMailCtrl', function ($scope, $routeParams, $location, LocalStorageService, VerifyConfirmMailSvc) {
    VerifyConfirmMail();
    function VerifyConfirmMail() {
        let uid = $routeParams.uid;
        let token = $routeParams.token;
        if (uid && token) {
            var result = VerifyConfirmMailSvc.verifyConfirmEmail(uid, token);
            result.then(function (response, status, headers, config) {
                let obj = response.data;
                if (obj.responseCode === 200) {
                    $scope.isVerified = true;
                    $scope.message = obj.message
                }
            }).catch((error) => {
                $scope.isVerified = false;
                $scope.message = error.data.message
            });
        }
    }
})