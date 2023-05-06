am4core.useTheme(am4themes_animated);

var chart = am4core.create("callChart", am4charts.PieChart);


chart.data = [{
    "country": "Income",
    "litres": 753
}, {
    "country": "Outcome",
    "litres": 398
}, {
    "country": "Missed calls",
    "litres": 32
}, {
    "country": "Inc. Answered",
    "litres": 721
}, {
    "country": "Out. Answered",
    "litres": 144
}, {
    "country": "Effort calls",
    "litres": 1119
}, {
    "country": "Effective calls",
    "litres": 865
}];

var series = chart.series.push(new am4charts.PieSeries());
series.dataFields.value = "litres";
series.dataFields.category = "country";

// this creates initial animation
series.hiddenState.properties.opacity = 1;
series.hiddenState.properties.endAngle = -90;
series.hiddenState.properties.startAngle = -90;

chart.legend = new am4charts.Legend();