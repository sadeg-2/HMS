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