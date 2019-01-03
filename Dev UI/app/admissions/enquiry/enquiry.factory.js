(function () {
    'use strict';

    angular
        .module('ms')
        .factory('enquiryFactory', Service);

    Service.$inject = ['$state', '$q', '$http', 'apiCollection', 'enquiryListFactory', '$log', 'lookUps'];
    function Service($state, $q, $http, apiCollection, enquiryListFactory, $log, lookUps) {
        var enquiryData = {};
        var service = {
            getEnquiry: getEnquiry,
            submit: submit,
            showCancelAlert: showCancelAlert
        };

        return service;

        ////////////////
        function getEnquiry(id) {
            var defer = $q.defer();
            if (enquiryData.id !== id) {
                $http.get(apiCollection.enquiry.getById(id)).then(function (result) {
                    enquiryData = result.data.table[0];
                    defer.resolve(result.data.table[0]);
                });
            } else {
                defer.resolve(enquiryData);
            }

            return defer.promise;
        }

        function submit(mode, enquiry, form) {
            var defer = $q.defer();
            $http.post(apiCollection.enquiry.update(), enquiry).then(function (result) {
                defer.resolve(result.data);
                if (result.data.success) {
                    showSuccessAlert(mode);
                    enquiryListFactory.resetData();
                } else {
                    swal({
                        title: 'Failed',
                        text: result.data.data,
                        type: 'error',
                        confirmButtonClass: "btn btn-info",
                        buttonsStyling: false
                    }).catch(swal.noop)
                }
            });
            return defer.promise;
        }
        function showSuccessAlert(mode) {
            var text = '';
            if (mode === 'Add') {
                text = 'added';
            } else {
                text = 'saved';
            }
            swal({
                title: "Success!",
                text: "Enquiry was " + text + " successfully!",
                buttonsStyling: false,
                confirmButtonClass: "btn btn-success",
                type: "success"
            }).then(function () {
                $state.go('main.enquiryList');
            }).catch(swal.noop)
        }
        function showCancelAlert() {
            swal({
                title: 'Are you sure you want to cancel?',
                text: "All your changes will be lost",
                type: 'warning',
                showCancelButton: true,
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger',
                confirmButtonText: 'Yes, Cancel it!',
                cancelButtonText: 'No, Stay on the page',
                buttonsStyling: false
            }).then(function () {
                $state.go('main.enquiryList');
            }).catch(swal.noop)
        }
    }
})();