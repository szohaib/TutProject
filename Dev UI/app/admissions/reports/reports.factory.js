(function() {
    'use strict';

    angular.module('ms').factory('ReportsChartService', ['$http',ReportsChartService]);
    function ReportsChartService($http) {
        var getChartData = function(){
            //Function to get data from the server
            return $http.get('http://127.0.0.1:5500/db.json'); 
        };
        var admissionReport = function(seriesData,drilldownData) {
            // function to configure the admission spline chart
            var admissionReport = {
                options: {
                    chart:{
                        type: 'spline',


                    },
                    colors:[
                        '#3CC2D6'
                    ],
                    title: {
                        text: "Admission Report"
                    },
                    drilldown: {
                        series: drilldownData
                    },
                    xAxis: {
                        type: 'category'
                    }, 
                    
                    yAxis: {  
                        title: {  
                            text: 'Number of Students'  
                        },  
                        plotLines: [{  
                            value: 0,  
                            width: 1,  
                            color: '#808080'  
                        }]  
                    },
                    plotOptions:{
                        column:{
                            colorBySeries: true
                        }
                    }
                },

                series: [{
                    data: seriesData,
                    name: 'Zone'
                }]
                

            };
            return admissionReport;
    };
    var concessionReport = function(seriesData2,drilldownData2) {
        // function to configure the concession area chart    
        var concessionReport = {

            options: {
                chart:{
                    type: 'area',

                },
                title: {
                    text: "Concession Report"
                },
                drilldown: {
                    series: drilldownData2
                }
                // tooltip: {
                //     headerFormat: '<span style="font-size:10px">{point.key}</span>',
                //     pointFormat: '<br /><span style="color:{series.color}"> <b>{point.y}%</b></span><br/>',
                //     shared: false
                // }



            },

            xAxis: {
                type: 'category'
            },
            yAxis: {  
                title: {  
                    text: 'Percentage'  
                },  
                plotLines: [{  
                    value: 0,  
                    width: 1,  
                    color: '#808080'  
                }]  
            },
            series: [{
                data: seriesData2,
                name: 'Zone',
                color: '#F99F33'
            }]

        };
        return concessionReport;
};
    var enquiryAdmissionReport = function(categoriesData,seriesData) {
        //function to configure the enquiry vs admission chart
        var enquiryAdmissionReport = {
            options: {
                chart:{
                    type: 'column'
                },
                colors: [
                    '#30BBD3',
                    '#EF433C'
                ],
                plotOptions: {
                    column: {
                        colorBySeries: true
                    }
                },
                title: {
                    text: "Admissions vs Enquiries"
                },
                xAxis: {
                    type: 'category',
                    categories: categoriesData,
                    crosshair: true
                },
                yAxis: {  
                    title: {  
                        text: 'Number of Students'  
                    },  
                    min: 0
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y}</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                }


            },

            series: seriesData


        };
        return enquiryAdmissionReport;
    };

        return{
            getChartData: getChartData,
            admissionReport: admissionReport,
            concessionReport: concessionReport,
            enquiryAdmissionReport: enquiryAdmissionReport


        }
    };
   
})();