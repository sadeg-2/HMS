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


