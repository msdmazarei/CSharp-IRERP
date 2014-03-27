using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_ChartType
    {
        Area,//	Values represented by area, with stacked values representing multiple facet values. This is equivalent to ChartType "Line" with stacking enabled.
        Column,//	Values represented by vertical columns. Typically supports stacking to represent two facets. May support simultaneous stacking and clustering for 3 facets.
        Bar,//Values represented by horizontal bars. Typically supports stacking to represent two facets. May support simultaneous stacking and clustering for 3 facets.
        Line,//Values represented by a lines between data points, or stacked areas for multiple facets.
        Radar,//Values represented on a circular background by a line around the center, or stacked areas for multiple facets
        Pie,//Circular chart with wedges representing values. Multiple or stacked pies for multiple facets.
        Doughnut,//	Like a pie chart with a central hole. Multiple or stacked doughnuts for multiple facets.
        Scatter,//A chart with two continuous numeric axes and up to one discrete facet.


    }
}