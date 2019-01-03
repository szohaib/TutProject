(function() {
    'use strict';

    angular
        .module('ms')
        .controller('layoutCtrl', layoutCtrl);

    layoutCtrl.$inject = ['$scope', '$http','$compile','lookUps','layoutFactory','$stateParams','$timeout'];
    function layoutCtrl($scope,$http,$compile,lookUps,layoutFactory,$stateParams,$timeout) {
        activate();
        // var vm = this;
        // $scope.feeData;
        $scope.feeStructureTable = {};
        $scope.feeStructureTable.dtColumnDefs;
        $scope.feeStructureTable.dtOptions;
        $scope.feeStructureTable.dataLoaded = false;
        $scope.isVisible = false
        $scope.showHide = function(){
            $scope.isVisible = $scope.isVisible ? false : true;
            
        }
        $scope.getFeeData = function(){
            $scope.feeData = layoutFactory.getFeeData();
        //     var html = '<table class=\'table table-bordered\'>'+
        //     '<thead>'+
        //         '<tr>'+
        //             '<th>'+
        //                 'Groups'+
        //             '</th>'+
        //             '<th>'+
        //                 'Course'+
        //             '</th>'+
        //             '<th>'+
        //                 'Total Fee'+
        //             '</th>'+
        //             '<th>'+
        //                 'Admin Fee'+
        //             '</th>'+
        //             '<th>'+
        //                 'Tution Fee'+
        //             '</th>'+
        //             '<th>'+
        //                 '1st Term'+
        //             '</th>'+
        //             '<th>'+
        //                 '2nd Term'+
        //             '</th>'+
        //             '<th>'+
        //                 '3rd Term'+
        //             '</th>'+
        //             '<th>'+
        //                 '4th Term'+
        //             '</th>'+
        //         '</tr>'+
        //     '</thead>'+
        //     '<tbody>'+
        //         '<tr><td>{{feeData.feeStructure[0].courseName}}</td></tr>'
        //     '</tbody>'+
        //   '</table>';
        // var content = $compile($(html).contents())($scope)
          
        //     swal({
        //     title: 'HTML example',
        //         buttonsStyling: false,
        //         confirmButtonClass: "btn btn-success",
        //         html: content,
               

        // })
    };
    
    
    // $http.get(apiCollection.feeStructure.getByIDs())
    // .then(function(response) {
    //     $scope.feeData = response.data;
    // });

        
        ////////////////

        function activate() {

            lookUps.loadLookUps().then(function() {
                $scope.$broadcast('lookUpsLoaded');
            }); 
            var educationLevelId = 1;
            var branchId = 1;
            var userId = 1;
            layoutFactory.loadFeeStructure(educationLevelId,branchId,userId).then(function(data){
                console.log(data.feeStructure[0].totalFees);
                $scope.feeStructureTable.dataLoaded = true;
                $scope.feeStructureTable.dtOptions = layoutFactory.getFeeGridOptions();
                $scope.feeStructureTable.dtOptions.data = data.feeStructure;
               
                
            })
            
                
            
           
        
         
    }
}
})();