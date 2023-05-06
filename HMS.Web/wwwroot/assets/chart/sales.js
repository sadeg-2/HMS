//-------------------------------------//
            // sales_chart
//-------------------------------------//
am4core.ready(function() {
// Themes begin
am4core.useTheme(am4themes_animated);
// Themes end

var chart = am4core.create("sales_chart", am4charts.XYChart);

    $.ajax({
        url: '/Dashboard/GetCollectionDashboard',
        dataType: "json",
        type: "POST",
        data: {
            From: "2020-01-01",
            To: "2020-12-31"
        },
        success: function (Data) {
            //var json = $.parseJSON(Data);
            //chart.data = json;
             $(Data.data).each(function (index, value) {
                chart.data = [{
                    "date": 11,
                    "BSA": value.BSA,
                    "VDSL": value.VDSL,
                    "WIFI": value.WIFI,
                    "HotSpot": value.Hotspot
                }];
            });
        }
    });





//chart.dateFormatter.inputDateFormat = "yyyy-MM-dd";
var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
//dateAxis.renderer.minGridDistance = 10;
//dateAxis.startLocation = 0.5;
//dateAxis.endLocation = 0.5;
//dateAxis.baseInterval = {
//  timeUnit: "month",
//  count: 1
//}

var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
valueAxis.tooltip.disabled = true;

var topContainer = chart.chartContainer.createChild(am4core.Container);
topContainer.layout = "absolute";
topContainer.toBack();
topContainer.paddingBottom = 15;
topContainer.width = am4core.percent(100);

var axisTitle = topContainer.createChild(am4core.Label);
axisTitle.text = "Collections";
axisTitle.fontWeight = 600;
axisTitle.align = "left";
axisTitle.paddingLeft = 10;

// var dateTitle = topContainer.createChild(am4core.Label);
// dateTitle.text = "Date- Months";
// dateTitle.fontWeight = 600;
// dateTitle.align = "right";


var series = chart.series.push(new am4charts.LineSeries());
series.dataFields.dateX = "date";
series.name = "BSA";
series.dataFields.valueY = "BSA";
series.tooltipText = "[#000]{valueY.value}[/]";
series.tooltip.background.fill = am4core.color("#FFF");
series.tooltip.getStrokeFromObject = true;
series.tooltip.background.strokeWidth = 3;
series.tooltip.getFillFromObject = false;
series.fillOpacity = 0.6;
series.strokeWidth = 2;
series.stacked = true;

var series2 = chart.series.push(new am4charts.LineSeries());
series2.name = "VDSL";
series2.dataFields.dateX = "date";
series2.dataFields.valueY = "VDSL";
series2.tooltipText = "[#000]{valueY.value}[/]";
series2.tooltip.background.fill = am4core.color("#FFF");
series2.tooltip.getFillFromObject = false;
series2.tooltip.getStrokeFromObject = true;
series2.tooltip.background.strokeWidth = 3;
series2.sequencedInterpolation = true;
series2.fillOpacity = 0.6;
series2.stacked = true;
series2.strokeWidth = 2;

var series3 = chart.series.push(new am4charts.LineSeries());
series3.name = "WIFI";
series3.dataFields.dateX = "date";
series3.dataFields.valueY = "WIFI";
series3.tooltipText = "[#000]{valueY.value}[/]";
series3.tooltip.background.fill = am4core.color("#FFF");
series3.tooltip.getFillFromObject = false;
series3.tooltip.getStrokeFromObject = true;
series3.tooltip.background.strokeWidth = 3;
series3.sequencedInterpolation = true;
series3.fillOpacity = 0.6;
series3.stacked = true;
series3.strokeWidth = 2;

var series4 = chart.series.push(new am4charts.LineSeries());
series4.name = "HotSpot";
series4.dataFields.dateX = "date";
series4.dataFields.valueY = "HotSpot";
series4.tooltipText = "[#000]{valueY.value}[/]";
series4.tooltip.background.fill = am4core.color("#FFF");
series4.tooltip.getFillFromObject = false;
series4.tooltip.getStrokeFromObject = true;
series4.tooltip.background.strokeWidth = 3;
series4.sequencedInterpolation = true;
series4.fillOpacity = 0.6;
series4.defaultState.transitionDuration = 1000;
series4.stacked = true;
series4.strokeWidth = 2;



chart.cursor = new am4charts.XYCursor();
chart.cursor.xAxis = dateAxis;
chart.scrollbarX = new am4core.Scrollbar();

// Add a legend
chart.legend = new am4charts.Legend();
chart.legend.position = "top";

}); // end am4core.ready()




//-------------------------------------//
            // sales_chart2
//-------------------------------------//
// Year chart //
am4core.ready(function() {

// Themes begin
am4core.useTheme(am4themes_animated);
// Themes end

var chart = am4core.create("sales_chart2", am4charts.XYChart);

chart.data = [{
  "year": "2015",
  "BSA": 3000,
  "VDSL": 1650,
  "WIFI": 121,
  "HotSpot": 50
}, {
  "year": "2016",
  "BSA": 1500,
  "VDSL": 1483,
  "WIFI": 146,
  "HotSpot": 80
}, {
  "year": "2017",
  "BSA": 1000,
  "VDSL": 1591,
  "WIFI": 138,
  "HotSpot": 50
}, {
  "year":"2018",
  "BSA": 1500,
  "VDSL": 142,
  "WIFI": 127,
  "HotSpot": 50
}, {
  "year": "2019",
  "BSA": 2000,
  "VDSL": 1399,
  "bicycles": 105,
  "HotSpot": 150
}, {
  "year": "2020",
  "BSA": 1683,
  "VDSL": 1821,
  "WIFI": 109,
  "HotSpot": 30
}, {
  "year":"2020",
  "BSA": 1452,
  "VDSL": 1520,
  "WIFI": 112,
  "HotSpot": 10
}];

chart.colors.list = [
  am4core.color("#845EC2"),
  am4core.color("#D65DB1"),
  am4core.color("#FF6F91"),
  am4core.color("#FF9671"),
  am4core.color("#FFC75F"),
  am4core.color("#F9F871")
];

chart.dateFormatter.inputDateFormat = "yyyy";
var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
dateAxis.renderer.minGridDistance = 60;
dateAxis.startLocation = 0.5;
dateAxis.endLocation = 0.5;
dateAxis.baseInterval = {
  timeUnit: "year",
  count: 1
}

var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
valueAxis.tooltip.disabled = true;

var topContainer = chart.chartContainer.createChild(am4core.Container);
topContainer.layout = "absolute";
topContainer.toBack();
topContainer.paddingBottom = 15;
topContainer.width = am4core.percent(100);

var axisTitle = topContainer.createChild(am4core.Label);
axisTitle.text = "Collections";
axisTitle.fontWeight = 600;
axisTitle.align = "left";
axisTitle.paddingLeft = 10;


var series = chart.series.push(new am4charts.LineSeries());
series.dataFields.dateX = "year";
series.name = "BSA";
series.dataFields.valueY = "BSA";
series.tooltipText = "[#000]{valueY.value}[/]";
series.tooltip.background.fill = am4core.color("#FFF");
series.tooltip.getStrokeFromObject = true;
series.tooltip.background.strokeWidth = 3;
series.tooltip.getFillFromObject = false;
series.fillOpacity = 0.6;
series.strokeWidth = 2;
series.stacked = true;

var series2 = chart.series.push(new am4charts.LineSeries());
series2.name = "VDSL";
series2.dataFields.dateX = "year";
series2.dataFields.valueY = "VDSL";
series2.tooltipText = "[#000]{valueY.value}[/]";
series2.tooltip.background.fill = am4core.color("#FFF");
series2.tooltip.getFillFromObject = false;
series2.tooltip.getStrokeFromObject = true;
series2.tooltip.background.strokeWidth = 3;
series2.sequencedInterpolation = true;
series2.fillOpacity = 0.6;
series2.stacked = true;
series2.strokeWidth = 2;

var series3 = chart.series.push(new am4charts.LineSeries());
series3.name = "WIFI";
series3.dataFields.dateX = "year";
series3.dataFields.valueY = "WIFI";
series3.tooltipText = "[#000]{valueY.value}[/]";
series3.tooltip.background.fill = am4core.color("#FFF");
series3.tooltip.getFillFromObject = false;
series3.tooltip.getStrokeFromObject = true;
series3.tooltip.background.strokeWidth = 3;
series3.sequencedInterpolation = true;
series3.fillOpacity = 0.6;
series3.stacked = true;
series3.strokeWidth = 2;

var series4 = chart.series.push(new am4charts.LineSeries());
series4.name = "HotSpot";
series4.dataFields.dateX = "year";
series4.dataFields.valueY = "HotSpot";
series4.tooltipText = "[#000]{valueY.value}[/]";
series4.tooltip.background.fill = am4core.color("#FFF");
series4.tooltip.getFillFromObject = false;
series4.tooltip.getStrokeFromObject = true;
series4.tooltip.background.strokeWidth = 3;
series4.sequencedInterpolation = true;
series4.fillOpacity = 0.6;
series4.defaultState.transitionDuration = 1000;
series4.stacked = true;
series4.strokeWidth = 2;



chart.cursor = new am4charts.XYCursor();
chart.cursor.xAxis = dateAxis;
chart.scrollbarX = new am4core.Scrollbar();

// Add a legend
chart.legend = new am4charts.Legend();
chart.legend.position = "top";

}); // end am4core.ready()



//-------------------------------------//
            //BSA
//-------------------------------------//
am4core.ready(function() {

// Themes begin
am4core.useTheme(am4themes_animated);
// Themes end

// Create chart instance
var chart = am4core.create("BSAChart", am4charts.XYChart);

// Export
chart.exporting.menu = new am4core.ExportMenu();

// Data for both series
var data = [ {
  "month": "Jan",
  "income": 23.5,
  "expenses": 21.1
}, {
  "month": "Feb",
  "income": 26.2,
  "expenses": 30.5
}, {
  "month": "Mar",
  "income": 30.1,
  "expenses": 34.9
}, {
  "month": "Apr",
  "income": 29.5,
  "expenses": 31.1
}, {
  "month": "May",
  "income": 30.6,
  "expenses": 28.2,
  "lineDash": "5,5",
}, {
  "month": "Jun",
  "income": 34.1,
  "expenses": 32.9,
  "strokeWidth": 1,
  "columnDash": "5,5",
  "fillOpacity": 0.2,
  "additional": "(projection)"
} ];

/* Create axes */
var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
categoryAxis.dataFields.category = "month";
categoryAxis.renderer.minGridDistance = 30;

/* Create value axis */
var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

/* Create series */
var columnSeries = chart.series.push(new am4charts.ColumnSeries());
columnSeries.name = "Income";
columnSeries.dataFields.valueY = "income";
columnSeries.dataFields.categoryX = "month";

columnSeries.columns.template.tooltipText = "[#fff font-size: 15px]{name} in {categoryX}:\n[/][#fff font-size: 20px]{valueY}[/] [#fff]{additional}[/]"
columnSeries.columns.template.propertyFields.fillOpacity = "fillOpacity";
columnSeries.columns.template.propertyFields.stroke = "stroke";
columnSeries.columns.template.propertyFields.strokeWidth = "strokeWidth";
columnSeries.columns.template.propertyFields.strokeDasharray = "columnDash";
columnSeries.tooltip.label.textAlign = "middle";

var lineSeries = chart.series.push(new am4charts.LineSeries());
lineSeries.name = "Expenses";
lineSeries.dataFields.valueY = "expenses";
lineSeries.dataFields.categoryX = "month";

lineSeries.stroke = am4core.color("#fdd400");
lineSeries.strokeWidth = 3;
lineSeries.propertyFields.strokeDasharray = "lineDash";
lineSeries.tooltip.label.textAlign = "middle";

var bullet = lineSeries.bullets.push(new am4charts.Bullet());
bullet.fill = am4core.color("#fdd400"); // tooltips grab fill from parent by default
bullet.tooltipText = "[#fff font-size: 15px]{name} in {categoryX}:\n[/][#fff font-size: 20px]{valueY}[/] [#fff]{additional}[/]"
var circle = bullet.createChild(am4core.Circle);
circle.radius = 4;
circle.fill = am4core.color("#fff");
circle.strokeWidth = 3;

chart.data = data;

}); // end am4core.ready()






//-------------------------------------//
            // User_Statistics
//-------------------------------------//
// am4core.ready(function() {

// // Themes begin
// am4core.useTheme(am4themes_animated);
// // Themes end

// // Create chart instance
// var chart = am4core.create("User_Statistics", am4charts.XYChart);

// // Add data
// chart.data = [{
//   "month": "Jan",
//   "new": 20,
//   "active": 20,
//   "non-Active": 10,
//   "restore": 5,
//   "free": 12
// }, {
//   "month": "Feb",
//   "new": 14,
//   "active": 25,
//   "non-Active": 20,
//   "restore": 13,
//   "free": 12
// }, {
//   "month": "Mar",
//   "new": 25,
//   "active": 40,
//   "non-Active": 15,
//   "restore": 20,
//   "free": 0
// },
// {
//   "month": "Apr",
//   "new": 12,
//   "active": 20,
//   "non-Active": 15,
//   "restore": 30,
//   "free": 5
// }, {
//   "month": "May",
//   "new": 15,
//   "active": 30,
//   "non-Active": 15,
//   "restore": 12,
//   "free": 3
// }, {
//   "month": "Jun",
//   "new": 30,
//   "active": 13,
//   "non-Active": 12,
//   "restore": 10,
//   "free": 0
// },
// {
//   "month": "Jul",
//   "new": 21,
//   "active": 25,
//   "non-Active": 45,
//   "restore": 0,
//   "free": 0
// }, {
//   "month": "Agu",
//   "new": 22,
//   "active": 27,
//   "non-Active": 22,
//   "restore": 3,
//   "free": 30
// }, {
//   "month": "Sep",
//   "new": 28,
//   "active": 39,
//   "non-Active": 24,
//   "restore": 13,
//   "free": 3
// },
// {
//   "month": "Oct",
//   "new": 54,
//   "active": 12,
//   "non-Active": 10,
//   "restore": 0,
//   "free": 0
// }, {
//   "month": "Nov",
//   "new": 21,
//   "active": 47,
//   "non-Active":13,
//   "restore": 15,
//   "free": 20
// }, {
//   "month": "Dec",
//   "new": 14,
//   "active": 10,
//   "non-Active": 22,
//   "restore": 50,
//   "free": 0
// }];

// chart.legend = new am4charts.Legend();
// chart.legend.position = "right";

// // Create axes
// var categoryAxis = chart.yAxes.push(new am4charts.CategoryAxis());
// categoryAxis.dataFields.category = "month";
// categoryAxis.renderer.grid.template.opacity = 0;

// var valueAxis = chart.xAxes.push(new am4charts.ValueAxis());
// valueAxis.min = 0;
// valueAxis.renderer.grid.template.opacity = 0;
// valueAxis.renderer.ticks.template.strokeOpacity = 0.5;
// valueAxis.renderer.ticks.template.stroke = am4core.color("#495C43");
// valueAxis.renderer.ticks.template.length = 10;
// valueAxis.renderer.line.strokeOpacity = 0.5;
// valueAxis.renderer.baseGrid.disabled = true;
// valueAxis.renderer.minGridDistance = 40;

// // Create series
// function createSeries(field, name) {
//   var series = chart.series.push(new am4charts.ColumnSeries());
//   series.dataFields.valueX = field;
//   series.dataFields.categoryY = "month";
//   series.stacked = true;
//   series.name = name;
  
//   var labelBullet = series.bullets.push(new am4charts.LabelBullet());
//   labelBullet.locationX = 0.5;
//   labelBullet.label.text = "{valueX}";
//   labelBullet.label.fill = am4core.color("#fff");
// }

// createSeries("new", "New");
// createSeries("active", "Active");
// createSeries("non-Active", "Non-Active");
// createSeries("restore", "Restore");
// createSeries("free", "Free");
// }); // end am4core.ready()



//-------------------------------------//
            // BSAChart
//-------------------------------------//
am4core.ready(function() {

// Themes begin
am4core.useTheme(am4themes_animated);
// Themes end

// Create chart instance
var chart = am4core.create("BSAChart", am4charts.XYChart);

// Export
chart.exporting.menu = new am4core.ExportMenu();

// Data for both series
var data = [ {
  "month": "Jan",
  "income": 23.5,
}, {
  "month": "Feb",
  "income": 26.2,
}, {
  "month": "Mar",
  "income": 30.1,
}, {
  "month": "Apr",
  "income": 29.5,
}, {
  "month": "May",
  "income": 30.6
}, {
  "month": "Jun",
  "income": 34.1
},{
  "month": "Jul",
  "income": 23.5,
}, {
  "month": "Agu",
  "income": 26.2,
}, {
  "month": "Sep",
  "income": 30.1,
}, {
  "month": "Oct",
  "income": 29.5,
}, {
  "month": "Nov",
  "income": 30.6
}, {
  "month": "Dec",
  "income": 25,
}];

/* Create axes */
var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
categoryAxis.dataFields.category = "month";
categoryAxis.renderer.minGridDistance = 30;

/* Create value axis */
var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

/* Create series */
var columnSeries = chart.series.push(new am4charts.ColumnSeries());
columnSeries.name = "Average";
columnSeries.dataFields.valueY = "income";
columnSeries.dataFields.categoryX = "month";



columnSeries.columns.template.tooltipText = "[#fff font-size: 15px]{name} in {categoryX}:\n[/][#fff font-size: 20px]{valueY}[/] [#fff]{additional}[/]"
columnSeries.columns.template.propertyFields.fillOpacity = "fillOpacity";
columnSeries.columns.template.propertyFields.stroke = "stroke";
columnSeries.columns.template.propertyFields.strokeWidth = "strokeWidth";
columnSeries.columns.template.propertyFields.strokeDasharray = "columnDash";
columnSeries.tooltip.label.textAlign = "middle";

var lineSeries = chart.series.push(new am4charts.LineSeries());
lineSeries.name = "Average";
lineSeries.dataFields.valueY = "income";
lineSeries.dataFields.categoryX = "month";

lineSeries.stroke = am4core.color("#fdd400");
lineSeries.strokeWidth = 3;
lineSeries.propertyFields.strokeDasharray = "lineDash";
lineSeries.tooltip.label.textAlign = "middle";

var bullet = lineSeries.bullets.push(new am4charts.Bullet());
bullet.fill = am4core.color("#fdd400"); // tooltips grab fill from parent by default
bullet.tooltipText = "[#fff font-size: 15px]{name} in {categoryX}:\n[/][#fff font-size: 20px]{valueY}[/] [#fff]{additional}[/]"
var circle = bullet.createChild(am4core.Circle);
circle.radius = 4;
circle.fill = am4core.color("#fff");
circle.strokeWidth = 3;

chart.data = data;



}); // end am4core.ready()



//------------------------------------------
am4core.ready(function() {

// Themes begin
am4core.useTheme(am4themes_animated);
// Themes end

// Create chart instance
var chart = am4core.create("chartdiv", am4charts.XYChart);


// Add data
chart.data = [{
  "month": "Jan",
  "BSA": 2.5,
  "VDSL": 2.5,
  "WIFI": 2.1,
  "HotSpot": 0.3,
  "Events": 0.2
}, {
  "month": "Feb",
  "BSA": 2.6,
  "VDSL": 2.7,
  "WIFI": 2.2,
  "HotSpot": 0.3,
  "Events": 0.3
}, {
  "month": "Mar",
  "BSA": 2.8,
  "VDSL": 2.9,
  "WIFI": 2.4,
  "HotSpot": 0.3,
  "Events": 0.3
},{
  "month": "Apr",
  "BSA": 2.5,
  "VDSL": 2.5,
  "WIFI": 2.1,
  "HotSpot": 0.3,
  "Events": 0.2
}, {
  "year": "May",
  "BSA": 2.6,
  "VDSL": 2.7,
  "WIFI": 2.2,
  "HotSpot": 0.3,
  "Events": 0.3
}, {
  "month": "Jun",
  "BSA": 2.8,
  "VDSL": 2.9,
  "WIFI": 2.4,
  "HotSpot": 0.3,
  "Events": 0.3
},{
  "month": "Jul",
  "BSA": 2.5,
  "VDSL": 2.5,
  "WIFI": 2.1,
  "HotSpot": 0.3,
  "Events": 0.2
}, {
  "month": "Agu",
  "BSA": 2.6,
  "VDSL": 2.7,
  "WIFI": 2.2,
  "HotSpot": 0.3,
  "Events": 0.3
}, {
  "month": "Sep",
  "BSA": 2.8,
  "VDSL": 2.9,
  "WIFI": 2.4,
  "HotSpot": 0.3,
  "Events": 0.3
}, {
  "month": "Oct",
  "BSA": 2.8,
  "VDSL": 2.9,
  "WIFI": 2.4,
  "HotSpot": 0.3,
  "Events": 0.3
}, {
  "month": "Nov",
  "BSA": 2.8,
  "VDSL": 2.9,
  "WIFI": 2.4,
  "HotSpot": 0.3,
  "Events": 0.3
},{
  "month": "Des",
  "BSA": 2.8,
  "VDSL": 2.9,
  "WIFI": 2.4,
  "HotSpot": 0.3,
  "Events": 0.3
}];

// Create axes
var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
categoryAxis.dataFields.category = "month";
categoryAxis.renderer.minGridDistance = 30;


var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
valueAxis.renderer.inside = true;
valueAxis.renderer.labels.template.disabled = true;
valueAxis.min = 0;


// Create series
function createSeries(field, name) {
  
  // Set up series
  var series = chart.series.push(new am4charts.ColumnSeries());
  series.name = name;
  series.dataFields.valueY = field;
  series.dataFields.categoryX = "month";
  series.sequencedInterpolation = true;

  // Make it stacked
  series.stacked = true;
  
  // Configure columns
  series.columns.template.width = am4core.percent(60);
  series.columns.template.tooltipText = "[bold]{name}[/]\n[font-size:14px]{categoryX}: {valueY}";

  // Add label
  var labelBullet = series.bullets.push(new am4charts.LabelBullet());
  labelBullet.label.text = "{valueY}";
  labelBullet.locationY = 0.5;
  labelBullet.label.hideOversized = true;
  
  return series;
}
createSeries("BSA", "BSA");
createSeries("VDSL", "VDSL");
createSeries("WIFI", "WIFI");
createSeries("HotSpot", "HotSpot");
createSeries("Events", "Events");

// Legend
chart.legend = new am4charts.Legend();

}); // end am4core.ready()


/////////////////////////////////////
//          places                //
////////////////////////////////////
am4core.ready(function() {

// Themes begin
am4core.useTheme(am4themes_animated);
// Themes end

// Create chart instance
var chart = am4core.create("places", am4charts.PieChart);

// Add data
chart.data = [ {
  "place": "الشركة",
  "value": 501.9
}, {
  "place": "المعرض",
  "value": 301.9
}, {
  "place": "الموزعين",
  "value": 201.1
}];

// Add and configure Series
var pieSeries = chart.series.push(new am4charts.PieSeries());
pieSeries.dataFields.category = "place";
pieSeries.dataFields.value = "value";
pieSeries.slices.template.stroke = am4core.color("#fff");
pieSeries.slices.template.strokeWidth = 2;
pieSeries.slices.template.strokeOpacity = 1;

// This creates initial animation
pieSeries.hiddenState.properties.opacity = 1;
pieSeries.hiddenState.properties.endAngle = -90;
pieSeries.hiddenState.properties.startAngle = -90;

pieSeries.colors.list = [
    am4core.color("#00c5dc"),
    am4core.color("#f4516c"),
    am4core.color("#ffb822")
];

}); // end am4core.ready()