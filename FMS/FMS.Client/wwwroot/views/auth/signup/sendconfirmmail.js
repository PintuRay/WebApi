var app = angular.module('templating_app');
app.service("SendConfirmMailSvc", function ($http, apiUrl) {

})
app.controller('SendConfirmMailCtrl', function ($scope, $routeParams, $location, LocalStorageService, SendConfirmMailSvc) {
    $scope.message = $routeParams.message;
})