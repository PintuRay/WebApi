var app = angular.module('templating_app');
app.service("ResendConfirmMailSvc", function ($http, apiUrl) {
    this.resendConfirmEmail = function (mail) {
        var response = $http({
            method: "get",
            url: apiUrl + "SignUp/ResendConfirmEmail?mail=" + mail,
            headers: {
                'Content-Type': 'application/json'
            }
        })
        return response;
    }
})
app.controller('ResendConfirmMailCtrl', function ($scope, $routeParams, $location, LocalStorageService, ResendConfirmMailSvc) {
    $scope.resendConfirmMail = function () {
        var result = SignUpSvc.signUp($scope.userEmail);
        result.then(function (response, status, headers, config) {
            let obj = response.data;

        }).catch((error) => {
            toastr.error();
        });
    }

})