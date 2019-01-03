(function() {
    'use strict';

      
    angular
        .module('ms')
        .controller('reportsCntrl', reportsCntrl);

    reportsCntrl.$inject = ['$scope','$state','ReportsChartService'];

    function reportsCntrl($scope,$state,ReportsChartService) {


        activate();

        ////////////////
        //Get call to fetch the data in the reports service
        ReportsChartService.getChartData().then(function(response){
            $scope.data = response.data.reportsData;
            //Calling admission report config in reports service
            $scope.admissionReport = ReportsChartService.admissionReport($scope.data.admissionChart.zone, $scope.data.admissionChart.dat);
            //Calling admissionEnquiryReport config in reports service
            $scope.enquiryAdmissionReport = ReportsChartService.enquiryAdmissionReport($scope.data.admissionEnquiry.branch, $scope.data.admissionEnquiry.data);
            //Calling concession report config in reports service
            $scope.concessionReport = ReportsChartService.concessionReport($scope.data.concessionChart.zone2,$scope.data.concessionChart.dat2);
        });
          

        function activate() { }
    }
})();