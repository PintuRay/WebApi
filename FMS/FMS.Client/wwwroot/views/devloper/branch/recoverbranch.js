var app = angular.module('templating_app');
app.service("RecoverBranchSvc", function ($http, apiUrl, LocalStorageService) {
    this.getAllRemovedBranch = function () {
        return $http.get(apiUrl + "Branch/GetAllRemovedBranch", {
            headers: {
                'Authorization': 'Bearer ' + LocalStorageService.getToken()
            }
        });
    };
    this.recoverBranch = function (id) {
        return $http.patch(apiUrl + "Branch/RecoverBranch/" + id, {
            headers: {
                'Authorization': 'Bearer ' + LocalStorageService.getToken()
            }
        });
    };
    this.deleteBranch = function (branchId) {
        return $http.delete(apiUrl + "Branch/DeleteBranch/" + branchId, {
            headers: {
                'Authorization': 'Bearer ' + LocalStorageService.getToken()
            }
        });
    };
    this.recoverAllBranch = function (ids) {
        return $http.post(apiUrl + "Branch/RecoverAllBranch/", ids ,{
            headers: {
                'Authorization': 'Bearer ' + LocalStorageService.getToken()
            }
        });
    };
    this.deleteAllBranch = function (Ids) {
        return $http.post(apiUrl + "Branch/DeleteAllBranch/", Ids, {
            headers: {
                'Authorization': 'Bearer ' + LocalStorageService.getToken()
            }
        });
    };
});
app.controller('RecoverBranchCtrl', function ($scope, $routeParams, $location, $timeout, RecoverBranchSvc) {
    var vm = this;
    vm.removedBranches = [];
    vm.selectedBranches = [];
    /* ---------------------------------Recover Operation-------------------- */
    vm.loadRemovedBranch = function () {
        var result = RecoverBranchSvc.getAllRemovedBranch();
        result.then(function (response, status, headers, config) {
            let obj = response.data;
            if (obj.responseCode === 200) {
                vm.removedBranches = obj.data;
            }
        }).catch((error) => {
            console.log(error);
        });
    }
    vm.loadRemovedBranch();
    vm.recover = function (branchId) {
        vm.loading = true;
        var result = RecoverBranchSvc.recoverBranch(branchId);
        result.then(function (response, status, headers, config) {
            vm.loading = false;
            let obj = response.data;
            if (obj.responseCode === 200) {
                vm.removedBranches = vm.removedBranches.filter(function (branch) {
                    return branch.branchId !== branchId;
                });
                toastr.success(obj.message);
            }
        }).catch((error) => {
            vm.loading = false;
            console.log(error);
        });
    }
    vm.delete = function (branchId) {
        vm.loading = true;
        var result = RecoverBranchSvc.deleteBranch(branchId);
        result.then(function (response, status, headers, config) {
            vm.loading = false;
            let obj = response.data;
            if (obj.responseCode === 200) {
                vm.removedBranches = vm.removedBranches.filter(function (branch) {
                    return branch.branchId !== branchId;
                });
                toastr.success(obj.message);
            }
        }).catch((error) => {
            vm.loading = false;
            console.log(error);
        });
    }
    vm.recoverAll = function () {
        if (vm.selectedBranches.length > 0) {
            vm.loading = true;
            var result = RecoverBranchSvc.recoverAllBranch(vm.selectedBranches);
            result.then(function (response, status, headers, config) {
                vm.loading = false;
                let obj = response.data;
                if (obj.responseCode === 200) {
                    vm.removedBranches = [];
                    toastr.success(obj.message);
                }
            }).catch((error) => {
                vm.loading = false;
                console.log(error);
            });
        }
        else {
            toastr.warning("Nothing Selected");
        }
    }
    vm.deleteAll = function () {
        if (vm.selectedBranches.length > 0) {
            vm.loading = true;
            var result = RecoverBranchSvc.deleteAllBranch(vm.selectedBranches);
            result.then(function (response, status, headers, config) {
                vm.loading = false;
                let obj = response.data;
                if (obj.responseCode === 200) {
                    vm.removedBranches = [];
                    toastr.success(obj.message);
                }
            }).catch((error) => {
                vm.loading = false;
                console.log(error);
            });
        }
        else {
            toastr.warning("Nothing Selected");
        }
    }
    vm.toggleSelection = function (id) {
        var idx = vm.selectedBranches.indexOf(id);
        if (idx > -1) {
            vm.selectedBranches.splice(idx, 1);
        } else {
            vm.selectedBranches.push(id);
        }
    }
    vm.toggleAll = function () {
        if (vm.selectAll) {
            vm.selectedBranches = vm.removedBranches.map(function (branch) {
                return branch.branchId;
            });
        } else {
            vm.selectedBranches = [];
        }
    };
    vm.isSelected = function (id) {
        return vm.selectedBranches.indexOf(id) > -1;
    };
});