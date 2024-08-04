var app = angular.module('templating_app');
app.service("BranchSvc", function ($http, apiUrl, LocalStorageService) {
    this.getAllBranch = function () {
        return $http.get(apiUrl + "Branch/GetAllBranch", {
            headers: {
                'Authorization': 'Bearer ' + LocalStorageService.getToken()
            }
        });
    };
    this.createBranch = function (branch) {
        return $http.post(apiUrl + "Branch/CreateBranch", branch, {
            headers: {
                'Authorization': 'Bearer ' + LocalStorageService.getToken()
            }
        });
    };
    this.updateBranch = function (id, branch) {
        return $http.put(apiUrl + "Branch/UpdateBranch/" + id, branch, {
            headers: {
                'Authorization': 'Bearer ' + LocalStorageService.getToken()
            }
        });
    };
    this.removeBranch = function (Id) {
        return $http.delete(apiUrl + "Branch/RemoveBranch/BranchId/" + Id, {
            headers: {
                'Authorization': 'Bearer ' + LocalStorageService.getToken()
            }
        });
    };
});
app.controller('BranchCtrl', function ($scope, $routeParams, $location, $timeout, BranchSvc) {

    /* ----------------------Variable Declaration-----------------------------*/
    var vm = this;
    vm.loading = false;
    vm.Branches = [];
    vm.cloneBranches = [];
    vm.isUpdate = false;
    vm.branchId = '';
    vm.branchName = '';
    vm.branchCode = '';
    vm.contactNumber = '';
    vm.branchAddress = '';
    /* ---------------Table paging, Sorting , Searching, Filtering----------------- */
    //Table property
    vm.predicate = 'branchName';
    vm.reverse = true;
    vm.totalItems = 0;
    vm.currentPage = 1;
    vm.pageRange = 2;
    vm.limit = 5;
    vm.searchQuery = '';
    //paging
    vm.generatePageNumbers = function () {
        vm.pageNumbers = [];
        var totalPages = Math.ceil(vm.totalItems / vm.limit);
        if (totalPages > 1) {
            var startPage = Math.max(1, vm.currentPage - vm.pageRange);
            var endPage = Math.min(totalPages, vm.currentPage + vm.pageRange);
            for (var i = startPage; i <= endPage; i++) {
                vm.pageNumbers.push(i);
            }
        }
    };
    vm.pagingBranches = function () {
        var start = (vm.currentPage - 1) * vm.limit;
        var end = start + vm.limit;
        return vm.Branches.slice(start, end);
    }
    //sorting
    vm.order = function (predicate) {
        vm.reverse = (vm.predicate === predicate) ? !vm.reverse : false;
        vm.predicate = predicate;
        vm.generatePageNumbers();
    }
    //Filtering
    vm.changeLimit = function () {
        vm.currentPage = 1;
        vm.limit = Number(vm.limit);
        vm.totalItems = vm.Branches.length;
        vm.generatePageNumbers();
    };
    //searching
    $scope.$watch('vm.searchQuery', function (newValue, oldValue) {
        if (newValue === '') {
            vm.Branches = vm.cloneBranches;
            vm.currentPage = 1;
            vm.totalItems = vm.cloneBranches.length;
        } else {
            vm.currentPage = 1;
            vm.Branches = vm.cloneBranches.filter(function (item) {
                return vm.contains(item, vm.searchQuery);
            });
            vm.totalItems = vm.Branches.length;
        }
        vm.generatePageNumbers();
    });
    vm.contains = function (item, query) {
        query = query.toLowerCase();
        return (
            item.branchName.toLowerCase().indexOf(query) !== -1 ||
            item.branchCode.toLowerCase().indexOf(query) !== -1 ||
            item.contactNumber.toLowerCase().indexOf(query) !== -1 ||
            item.branchAddress.toLowerCase().indexOf(query) !== -1
        );
    };
    /* ---------------------------------Crud Operation-------------------- */
    vm.loadBranch = function () {
        vm.loading = true;
        var result = BranchSvc.getAllBranch();
        result.then(function (response, status, headers, config) {
            vm.loading = false;
            let obj = response.data;
            if (obj.responseCode === 200) {
                vm.Branches = obj.data;
                vm.cloneBranches = angular.copy(obj.data);
                vm.totalItems = vm.Branches.length;
                vm.generatePageNumbers();
            }
        }).catch((error) => {
            vm.loading = false;
            console.log(error);
        });
    }
    vm.loadBranch();
    vm.add = function () {
        clearForm();
        $('#myModal').modal('show');
    }
    vm.create = function () {
        if (!vm.branchName) {
            toastr.error("Branch Name Is Required");
            return;
        }
        else if (!vm.branchCode) {
            toastr.error("Branch Code Is Required");
            return;
        }
        else if (!vm.contactNumber) {
            toastr.error("Contact Number Is Required");
            return;
        }
        else if (!vm.branchAddress) {
            toastr.error("Address Is Required");
            return;
        }
        else {
            var branch = {
                BranchName: vm.branchName,
                BranchAddress: vm.branchAddress,
                ContactNumber: vm.contactNumber,
                BranchCode: vm.branchCode
            }
            vm.loading = true;
            var result = BranchSvc.createBranch(branch);
            result.then(function (response, status, headers, config) {
                vm.loading = false;
                let obj = response.data;
                if (obj.responseCode === 201) {
                    $('#myModal').modal('hide');
                    toastr.success(obj.message);
                    vm.Branches.push({
                        branchId: obj.data.id,
                        branchName: branch.BranchName,
                        branchAddress: branch.BranchAddress,
                        branchCode: branch.BranchCode,
                        contactNumber: branch.ContactNumber
                    });
                    vm.totalItems = vm.Branches.length;
                    vm.generatePageNumbers();
                }
            }).catch((error) => {
                vm.loading = false;
                console.log(error);
            });
        }
        clearForm();
    }
    vm.edit = function (branch) {
        vm.branchId = branch.branchId;
        vm.branchName = branch.branchName;
        vm.branchCode = branch.branchCode;
        vm.contactNumber = branch.contactNumber;
        vm.branchAddress = branch.branchAddress;
        vm.isUpdate = true;
        $('#myModal').modal('show');
    }
    vm.cancel = function () {
        clearForm();
    }
    vm.update = function () {
        var id = vm.branchId;
        var branch = {
            BranchName: vm.branchName,
            BranchAddress: vm.branchAddress,
            ContactNumber: vm.contactNumber,
            BranchCode: vm.branchCode
        }
        vm.loading = true;
        var result = BranchSvc.updateBranch(id, branch);
        result.then(function (response, status, headers, config) {
            vm.loading = false;
            let obj = response.data;
            if (obj.responseCode === 200) {
                $('#myModal').modal('hide');
                toastr.success(obj.message);
                var index = vm.Branches.findIndex(function (b) {
                    return b.branchId === obj.data.id;
                });
                if (index !== -1) {
                    var UpdateBranch = {
                        branchId: id,
                        branchName: branch.BranchName,
                        branchAddress: branch.BranchAddress,
                        branchCode: branch.BranchCode,
                        contactNumber: branch.ContactNumber
                    }
                    vm.Branches[index] = UpdateBranch;
                }

            }
        }).catch((error) => {
            vm.loading = false;
            console.log(error.data);
        });
        clearForm();
    }
    vm.remove = function (branchId) {
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            type: "warning",
            showCancelButton: !0,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then(function (t) {

            if (t.value) {
                vm.loading = true;
                var result = BranchSvc.removeBranch(branchId);
                result.then(function (response, status, headers, config) {
                    vm.loading = false;
                    let obj = response.data;
                    if (obj.responseCode === 200) {
                        vm.Branches = vm.Branches.filter(function (branch) {
                            return branch.branchId !== branchId;
                        })
                        $("#myTable tbody tr[data-id='" + branchId + "']").remove();
                        Swal.fire("Deleted!", "Your file has been deleted.", "success");
                        vm.totalItems = vm.Branches.length;
                        vm.generatePageNumbers();
                    }
                }).catch((error) => {
                    vm.loading = false;
                    let obj = error.data;
                    console.log(obj);
                });
            }
        })
    }
    function clearForm() {
        vm.isUpdate = false;
        vm.branchId = '';
        vm.branchName = '';
        vm.branchCode = '';
        vm.contactNumber = '';
        vm.branchAddress = '';
    }
    /* --------------------------------Vaildation-------------------------- */
    vm.validateForm = function () {

    }
});