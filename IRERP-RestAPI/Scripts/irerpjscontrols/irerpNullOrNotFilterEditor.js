irerp.defineClass('irerpNullOrNotFilterEditorItem', 'SelectItem');
irerp.irerpNullOrNotFilterEditorItem.addProperties({
    MsdNullTitle: "تهی است",
    MsdnotNullTitle: "مقدار دارد",
    init: function () {
        this.valueMap = { 0: this.MsdNullTitle, 1: this.MsdnotNullTitle };
            //[null, "notnull"];// {"null":this.MsdNullTitle,"notnull":this.MsdnotNullTitle};
        this.Super('init', arguments);
    },
    getCriterion: function (textmatchstyle) {
        result = { _constructor: "AdvancedCriteria", operator: "and", criteria: [] };
        switch (this.getValue()) {
            case "1":
                result.criteria.add(
                { fieldName: this.getCriteriaFieldName(), operator: "notNull" }
                );
                break;
            case "0":
                result.criteria.add({ fieldName: this.getCriteriaFieldName(), operator: "isNull" });
                break;
        }
        return result;
    },
    canEditCriterion: function (criterion) {
        if (criterion == null) return false;
        var fileField = this.getCriteriaFieldName();
        if (criterion.operator == "and") {
            var innerCriteria = criterion.criteria;
            // we always produce one or 2 criteria only (to and from date range) - note, however,
            // that we can also edit an "equals" criterion, by first converting it into a range

            if (innerCriteria.length == 0 || innerCriteria.length > 1) {
                return false;
            } else if (innerCriteria.length == 1) {
                var crit = innerCriteria[0];
                if (crit.fieldName != fileField) return false;
            }
                var innerCriterion = innerCriteria[0];

                // other field - just bail
                if (innerCriterion.fieldName != fileField) return false;

                // wrong operator - bail, but with a warning since this could confuse a 
                // developer
                if (innerCriterion.operator != "isNull" && innerCriterion.operator != "notNull") {
                    msdlog('irerpNullOrNotNullFilterEditor: has invalid Operator '+ innerCriterion.operator);
                    return false;
                }
            
            
            return true;

          
        } 

        // in this case it's not on our field at all
        return false;
    },
    setCriterion: function (criterion) {
        
        if (!criterion) return;
        criterion = criterion.criteria[0];
        
        if (criterion.operator == "isNull") {
            this.setValue(0);
        }
        if (criterion.operator == "notNull") {
            this.setValue(1);
        }
    },

});