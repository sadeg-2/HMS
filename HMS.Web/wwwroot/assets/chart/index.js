am4core.useTheme(am4themes_animated);

var chart = am4core.create("chartdiv", am4charts.XYChart);


chart.data = [{
	"category": "New",
	"value1": 1,
	"value2": 15
}, {
	"category": "On Hold",
	"value1": 1,
	"value2": 2
}, {
	"category": "On Progress",
	"value1": 1,
	"value2": 5
}, {
	"category": "Completed",
	"value1": 1,
	"value2": 10
}]

chart.padding(5, 5, 10, 5);
chart.legend = new am4charts.Legend();

chart.colors.step = 2;

var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
categoryAxis.dataFields.category = "category";
categoryAxis.renderer.minGridDistance = 60;
categoryAxis.renderer.grid.template.location = 0;
categoryAxis.interactionsEnabled = false;

var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
valueAxis.tooltip.disabled = true;
valueAxis.renderer.grid.template.strokeOpacity = 0.05;
valueAxis.renderer.minGridDistance = 20;
valueAxis.interactionsEnabled = false;
valueAxis.min = 0;
valueAxis.renderer.minWidth = 35;

var series1 = chart.series.push(new am4charts.ColumnSeries());
series1.columns.template.width = am4core.percent(80);
series1.columns.template.tooltipText = "{name}: {valueY.value}";
series1.name = "Manual Tickets";
series1.dataFields.categoryX = "category";
series1.dataFields.valueY = "value1";
series1.stacked = true;

var series2 = chart.series.push(new am4charts.ColumnSeries());
series2.columns.template.width = am4core.percent(80);
series2.columns.template.tooltipText = "{name}: {valueY.value}";
series2.name = "System Tickets";
series2.dataFields.categoryX = "category";
series2.dataFields.valueY = "value2";
series2.stacked = true;


chart.scrollbarX = new am4core.Scrollbar();