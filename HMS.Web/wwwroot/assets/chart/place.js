am4core.ready(function() {

// Themes begin
am4core.useTheme(am4themes_animated);
// Themes end

/**
 * Define data for each year
 */
var chartData = {

  "2000": [
    { "sector": "الشركة", "size": 5.1 },
    { "sector": "الموزعين", "size": 0.3 },
    { "sector": "المعرض", "size": 20.4 } ]
};

// Create chart instance
var chart = am4core.create("placediv", am4charts.PieChart);

// Add data
chart.data = [
  { "sector": "الشركة", "size": 6.6 },
  { "sector": "الموزعين", "size": 0.6 },
  { "sector": "المعرض", "size": 23.2 }
];

// Add label
chart.innerRadius = 100;
var label = chart.seriesContainer.createChild(am4core.Label);
// label.text = "1995";
label.horizontalCenter = "middle";
label.verticalCenter = "middle";
label.fontSize = 50;

// Add and configure Series
var pieSeries = chart.series.push(new am4charts.PieSeries());
pieSeries.dataFields.value = "size";
pieSeries.dataFields.category = "sector";

// Animate chart data
var currentYear = 2020;
function getCurrentData() {
  label.text = currentYear;
  var data = chartData[currentYear];
  currentYear++;
  if (currentYear > 2014)
    currentYear = 1995;
  return data;
}

function loop() {
  //chart.allLabels[0].text = currentYear;
  var data = getCurrentData();
  for(var i = 0; i < data.length; i++) {
    chart.data[i].size = data[i].size;
  }
  chart.invalidateRawData();
  chart.setTimeout( loop, 4000 );
}

loop();

}); // end am4core.ready()

// am4core.ready(function() {

// // Themes begin
// am4core.useTheme(am4themes_animated);
// // Themes end


// var chart = am4core.create("placediv", am4charts.RadarChart);

// chart.data = [{
//  "place": "الشركة",
//  "number": 2025
// }, {
//  "place": "الموزعين",
//  "number": 1882
// }, {
//  "place": "المعارض",
//  "number": 1809
// }];

// chart.innerRadius = am4core.percent(40)

// var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
// categoryAxis.renderer.grid.template.location = 0;
// categoryAxis.dataFields.category = "place";
// categoryAxis.renderer.minGridDistance = 60;
// categoryAxis.renderer.inversed = true;
// categoryAxis.renderer.labels.template.location = 0.5;
// categoryAxis.renderer.grid.template.strokeOpacity = 0.08;

// var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
// valueAxis.min = 0;
// valueAxis.extraMax = 0.1;
// valueAxis.renderer.grid.template.strokeOpacity = 0.08;

// chart.seriesContainer.zIndex = -10;


// var series = chart.series.push(new am4charts.RadarColumnSeries());
// series.dataFields.categoryX = "place";
// series.dataFields.valueY = "number";
// series.tooltipText = "{valueY.value}"
// series.columns.template.strokeOpacity = 0;
// series.columns.template.radarColumn.cornerRadius = 5;
// series.columns.template.radarColumn.innerCornerRadius = 0;


// chart.zoomOutButton.disabled = true;

// // as by default columns of the same series are of the same color, we add adapter which takes colors from chart.colors color set
// series.columns.template.adapter.add("fill", (fill, target) => {
//  return chart.colors.getIndex(target.dataItem.index);
// });

// setInterval(()=>{
//  am4core.array.each(chart.data, (item)=>{
//    item.number *= Math.random() * 0.5 + 0.5;
//    item.number += 10;
//  })
//  chart.invalidateRawData();
// }, 2000)

// categoryAxis.sortBySeries = series;

// chart.cursor = new am4charts.RadarCursor();
// chart.cursor.behavior = "none";
// chart.cursor.lineX.disabled = true;
// chart.cursor.lineY.disabled = true;

// var colorSet = new am4core.ColorSet();


// // series.colors.list = [
// //     am4core.color("#00c5dc"),
// //     am4core.color("#f4516c"),
// //     am4core.color("#ffb822")
// // ];

// }); // end am4core.ready()