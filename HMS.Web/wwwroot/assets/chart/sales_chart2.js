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