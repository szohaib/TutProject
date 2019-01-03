(function () {
    'use strict';

    angular
        .module('ms')
        .controller('admissionList', admissionList);

    admissionList.$inject = ['$scope', 'admissionListFactory','$anchorScroll','$location','$state'];
    function admissionList($scope, admissionListFactory,$anchorScroll,$location,$state) {
        $scope.admissionTable = {};
        $scope.admissionTable.dtColumnDefs;
        $scope.admissionTable.dtOptions;
        $scope.admissionTable.dataLoaded = false;
        activate();

        ////////////////

        $scope.edit = function(dataRow){
            $state.go('main.admission',{
                mode:'edit',
                educationLevelId:dataRow.educationLevelId,
                id:dataRow.id,
                userId:JSON.parse(sessionStorage.userDetails).data.userId
            })
        }

        function activate() {
            $location.hash('navbar');
            $anchorScroll();
            $location.hash('')
            admissionListFactory.getAdmissionList().then(function (data) {
               console.log($scope.admissionTable)
                $scope.admissionTable.dataLoaded = true;
                $scope.admissionTable.dtOptions = admissionListFactory.getAdmissionGridOptions();
                $scope.admissionTable.dtOptions.data = data;
            })
        }
    }
})();