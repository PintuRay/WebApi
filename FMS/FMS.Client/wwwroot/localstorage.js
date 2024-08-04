var app = angular.module('templating_app');
app.service("LocalStorageService", function ($window) {
    this.setToken = function (newToken) {
        $window.localStorage.setItem('token', newToken);
    };
    this.getToken = function () {
        return $window.localStorage.getItem('token');
    };
    this.removeToken = function () {
        $window.localStorage.removeItem('token');
    };
    this.isAuthenticated = function () {
        var token = $window.localStorage.getItem('token');
        if (!token) {
            return false;
        }
        try {
            var payload = JSON.parse($window.atob(token.split('.')[1]));
            return payload.exp > Date.now() / 1000;
        } catch (e) {
            return false;
        }
    }
    this.setUserMail = function (mail) {
        $window.localStorage.setItem('mail', mail);
    }
    this.getUserMail = function () {
        return $window.localStorage.getItem('mail');
    }
    this.removeUserMail = function () {
        $window.localStorage.removeItem('mail');
    }
    this.setBranchId = function (branchId) {
        $window.localStorage.setItem('branchId', branchId);
    }
    this.getBranchId = function () {
        return $window.localStorage.getItem('branchId');
    }
    this.removeBranchId = function () {
        $window.localStorage.removeItem('branchId');
    }
    this.setFinancialYearId = function (financialYearId) {
        $window.localStorage.setItem('financialYearId', financialYearId);
    }
    this.getFinancialYearId = function () {
        return $window.localStorage.getItem('financialYearId');
    }
    this.removeFinancialYearId = function () {
        $window.localStorage.removeItem('financialYearId');
    }
})