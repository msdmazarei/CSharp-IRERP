//////////////////////////////////// before }  , Must Remove anything other than ;

isc.defineClass("IRERPChart", "Label");
isc.IRERPChart.addProperties({
    initWidget: function () {
        this.Super("initWidget", arguments);
        this.useClipDiv = true;
    },

    init: function () {
        this.Super("init", arguments);
        this.useClipDiv = true;
    },
    resized: function () {
        if (this.plot != null) {
            this.plot.width = this.getWidth();
            this.plot.height = this.getHeight();
            this.plot.replot();
        }
    },
    plot: null,
    dataRenderer: function () { },
    chart_highlighter: {
        show: true,
        sizeAdjust: 7.5,
        tooltipContentEditor: function (str, seriesIndex, pointIndex, plot) {
            html = '<div>Gholi is <b>Here</b></div>';
            return html;
        }
    },

    chart_axis : {
                    xaxis: {
                        tickOptions: {
                            showMark: false,
                            showGridline: false, // wether to draw a gridline (across the whole grid) at this tick,
                            markSize: 4,        // length the tick will extend beyond the grid in pixels.  For
                                                // 'cross', length will be added above and below the grid boundary,
                            show: false,         // wether to show the tick (mark and label),
                            showLabel: false,    // wether to show the text label at the tick,
                            showGridline: false
                        },
                    renderer: $.jqplot.DateAxisRenderer,
                    drawMajorGridlines: false
                    },
                    yaxis: {
                        tickOptions: {
                            showMark: false,
                            showGridline: false, // wether to draw a gridline (across the whole grid) at this tick,
                            markSize: 4,        // length the tick will extend beyond the grid in pixels.  For
                                                // 'cross', length will be added above and below the grid boundary,
                            show: false,         // wether to show the tick (mark and label),
                            showLabel: false,    // wether to show the text label at the tick,
                            showGridline: false
                        }
                    }
         },
    replot: function () {

        if (this.plot != null) {
            this.plot.replot();
            return;
        }

        divid = this._clipDiv.id;
        if(divid!=null)
        this.plot = $.jqplot
             (

             divid,
                 [],
                {
                    width: this.getWidth(),
                    height: this.getHeight(),
                    dataRenderer: this.dataRenderer,
                    showTicks: false,        // wether or not to show the tick labels,
                    showTickMarks: false,    // wether or not to show the tick marks
                    axes: this.chart_axis,
                    highlighter: this.chart_highlighter
                }
         );
    }

    }
    );

