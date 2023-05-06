// am4core.useTheme(am4themes_animated);

// var chart = am4core.create("customerChart", am4charts.XYChart);
// chart.paddingRight = 20;

// var data = [];
// var visits = 10;
// for (var i = 1; i < 50000; i++) {
//   visits += Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);
//   data.push({ date: new Date(2018, 0, i), value: visits });
// }

// chart.data = data;

// var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
// dateAxis.renderer.grid.template.location = 0;
// dateAxis.minZoomCount = 5;

// // this makes the data to be grouped
// dateAxis.groupData = true;
// //dateAxis.groupCount = 200;

// var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

// var series = chart.series.push(new am4charts.LineSeries());
// series.dataFields.dateX = "date";
// series.dataFields.valueY = "value";
// series.tooltipText = "{valueY}";
// series.tooltip.pointerOrientation = "vertical";
// series.tooltip.background.fillOpacity = 0.5;

// chart.cursor = new am4charts.XYCursor();
// chart.cursor.xAxis = dateAxis;

// var scrollbarX = new am4core.Scrollbar();
// chart.scrollbarX = scrollbarX;





/**
 * ---------------------------------------
 * This demo was created using amCharts 4.
 *
 * For more information visit:
 * https://www.amcharts.com/
 *
 * Documentation is available at:
 * https://www.amcharts.com/docs/v4/
 * ---------------------------------------
 */

// Create chart instance
// var chart = am4core.create("customerChart", am4charts.XYChart);

// // Add data
// chart.data = [{
//   "date": new Date(2018, 3, 20),
//   "value": 90
// }, {
//   "date": new Date(2018, 3, 21),
//   "value": 102
// }, {
//   "date": new Date(2018, 3, 22),
//   "value": 65
// }];

// // Create axes
// var dateAxis = chart.xAxes.push(new am4charts.DateAxis());

// // Set date label formatting
// dateAxis.dateFormats.setKey("day", "MMMM dt");

// // Create value axis
// var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

// // Create series
// var series = chart.series.push(new am4charts.ColumnSeries());
// series.dataFields.valueY = "value";
// series.dataFields.dateX = "date";
// series.name = "Sales";




/**
 * ---------------------------------------
 * This demo was created using amCharts 4.
 * 
 * For more information visit:
 * https://www.amcharts.com/
 * 
 * Documentation is available at:
 * https://www.amcharts.com/docs/v4/
 * ---------------------------------------
 */

// // Themes begin
am4core.useTheme(am4themes_animated);
// Themes end

var chart = am4core.create("customerChart", am4charts.XYChart);
chart.paddingRight = 40;

var data = [];
var value = 50;
for (let i = -3650; i < 0; i++) {
  let date = new Date();
  date.setHours(0, 0, 0, 0);
  date.setDate(i);
  value -= Math.round((Math.random() < 0.5 ? 1 : -1) * Math.random() * 10);
  if (value < 0) {
    value = Math.round(Math.random() * 10);
  }
  data.push({ date: date, value: value });
}

chart.data = data;

// Create axes
var dateAxis = chart.xAxes.push(new am4charts.DateAxis());
dateAxis.renderer.minGridDistance = 60;
dateAxis.groupData = true;

var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());

// Create series
var series = chart.series.push(new am4charts.ColumnSeries());
series.dataFields.valueY = "value";
series.dataFields.dateX = "date";
series.tooltipText = "{value}"

series.tooltip.pointerOrientation = "vertical";

chart.cursor = new am4charts.XYCursor();
chart.cursor.snapToSeries = series;
chart.cursor.xAxis = dateAxis;

chart.scrollbarX = new am4core.Scrollbar();