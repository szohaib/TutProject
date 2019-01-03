(function () {
    'use strict';

    angular
        .module('ms')
        .controller('enquiryList', enquiryList);

    enquiryList.$inject = ['$scope', 'enquiryListFactory', '$anchorScroll', '$location', '$log','$state'];
    function enquiryList($scope, enquiryListFactory, $anchorScroll, $location, $log,$state) {
        $scope.enquiryTable = {};
        $scope.enquiryTable.dtColumnDefs;
        $scope.enquiryTable.dtOptions;
        $scope.enquiryTable.dataLoaded = false;
        activate();

        ////////////////

        $scope.edit = function (dataRow) {
            $state.go('main.enquiry', {
                mode: 'edit',
                id:dataRow.id
            })
        }

        function activate() {
            $location.hash('navbar');
            $anchorScroll();
            $location.hash('')
            enquiryListFactory.getEnquiryList().then(function (data) {
                $scope.enquiryTable.dataLoaded = true;
                $scope.enquiryTable.dtOptions = enquiryListFactory.getEnquiryGridOptions();
                $scope.enquiryTable.dtOptions.data = data;
            })
        }
    }
})();