using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.ExtensionFuncs.Double;
namespace MsdLib.CSharp.DALCore.Projections
{
    using System.Collections.Generic;
    using System.Text;
    using global::NHibernate;
    using global::NHibernate.Criterion;
    using global::NHibernate.SqlCommand;
    using global::NHibernate.Type;
    using MsdLib.ExtensionFuncs.Double;
    public class Projections
    {
        public static CalculatedProjection Calculated(MsdLib.CSharp.DALCore.Projections.CalculatedProjection.CalculationType type, IProjection firstProjection, IProjection secondProjection)
        {
            return new CalculatedProjection(type, firstProjection, secondProjection);
        }
        public static CalculatedProjection Calculated(MsdLib.CSharp.DALCore.Projections.CalculatedProjection.CalculationType type, IProjection firstProjection, double Number)
        {
            return new CalculatedProjection(type, firstProjection, Number);
        }
    }
    public class CalculatedProjection : SimpleProjection
    {
        private readonly CalculationType calculationType;
        private readonly IProjection firstProjection;
        private readonly IProjection secondProjection;
        private readonly double? Number;
        private readonly string firstPropertyName;
        private readonly string secondPropertyName;

        protected internal CalculatedProjection(CalculationType type, IProjection firstPropertyName, double Number)
        {
            this.calculationType = type;
            this.firstProjection= firstPropertyName;
            this.Number= Number;
           // System.Diagnostics.Debugger.Launch();
        }
        /// <summary>
        /// Initializes a new instance of the CalculatedProjection class
        /// </summary>
        /// <param name="type">The type of calculation</param>
        /// <param name="firstPropertyName">The name of the first property</param>
        /// <param name="secondPropertyName">The name of the second property</param>
        protected internal CalculatedProjection(CalculationType type, string firstPropertyName, string secondPropertyName)
        {
            this.calculationType = type;
            this.firstPropertyName = firstPropertyName;
            this.secondPropertyName = secondPropertyName;
            //System.Diagnostics.Debugger.Launch();
        }

        /// <summary>
        /// Initializes a new instance of the CalculatedProjection class
        /// </summary>
        /// <param name="type">The type of calculation</param>
        /// <param name="firstProjection">The first projection</param>
        /// <param name="secondProjection">The second projection</param>
        protected internal CalculatedProjection(CalculationType type, IProjection firstProjection, IProjection secondProjection)
        {
            this.calculationType = type;
            this.firstProjection = firstProjection;
            this.secondProjection = secondProjection;
        }

        /// <summary>
        /// The type of calculation
        /// </summary>
        public enum CalculationType
        {
            /// <summary>
            /// Addition + 
            /// </summary>
            Addition,

            /// <summary>
            /// Subtraction -
            /// </summary>
            Subtraction,

            /// <summary>
            /// Division /
            /// </summary>
            Division,

            /// <summary>
            /// Division *
            /// </summary>
            Multiplication,
        }

        /// <summary>
        /// Gets a value indicating whether the projection is grouped
        /// </summary>
        public override bool IsGrouped
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether IsAggregate.
        /// </summary>
        public override bool IsAggregate
        {
            get { return false; }
        }

        /// <summary>
        /// Converts the calculation into a string
        /// </summary>
        /// <returns>The string representation of the calculation</returns>
        public override string ToString()
        {
            var firstValue = this.firstProjection != null ? this.firstProjection.ToString() : this.firstPropertyName;
            var secondValue = this.secondProjection != null ? this.secondProjection.ToString() : this.secondPropertyName;

            return "(" + firstValue + TypeToString(this.calculationType) + secondValue + ")";
        }

        /// <summary>
        /// Gets the types involved in the query
        /// </summary>
        /// <param name="criteria">The current criteria</param>
        /// <param name="criteriaQuery">The criteria query</param>
        /// <returns>An array of IType</returns>
        public override IType[] GetTypes(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return new IType[] { NHibernateUtil.Double };
            /*
            var types = new List<IType>();

            if (this.firstProjection != null)
            {
                types.AddRange(this.firstProjection.GetTypes(criteria, criteriaQuery));
            }
            else
            {
                types.Add(criteriaQuery.GetType(criteria, this.firstPropertyName));
            }

            if (this.secondProjection != null)
            {
                types.AddRange(this.secondProjection.GetTypes(criteria, criteriaQuery));
            }
            else
            {
                types.Add(criteriaQuery.GetType(criteria, this.secondPropertyName));
            }

            return types.ToArray();
             * */
        }

        /// <summary>
        /// Converts the objects to an sql string representation
        /// </summary>
        /// <param name="criteria">The criteria being used in the query</param>
        /// <param name="loc">The location in the query</param>
        /// <param name="criteriaQuery">The criteria query</param>
        /// <param name="enabledFilters">List of enabled filters</param>
        /// <returns>The calculation as an sql string</returns>
        public override SqlString ToSqlString(ICriteria criteria, int loc, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            string first, second;
            if (Number != null)
            {
                first = global::NHibernate.Util.StringHelper.RemoveAsAliasesFromSql(this.firstProjection.ToSqlString(criteria, loc, criteriaQuery, enabledFilters)).ToString();
                second = ((double)Number).ToDecmialString();
            }
            else
            if ((this.firstProjection != null) && (this.secondProjection != null))
            {
                first = global::NHibernate.Util.StringHelper.RemoveAsAliasesFromSql(this.firstProjection.ToSqlString(criteria, loc, criteriaQuery, enabledFilters)).ToString();
                second = global::NHibernate.Util.StringHelper.RemoveAsAliasesFromSql(this.secondProjection.ToSqlString(criteria, loc, criteriaQuery, enabledFilters)).ToString();
            }
            else
            {
                first = criteriaQuery.GetColumn(criteria, this.firstPropertyName);
                second = criteriaQuery.GetColumn(criteria, this.secondPropertyName);
            }

            return new SqlString(new object[] { "(", first, TypeToString(this.calculationType), second, ") as y", loc.ToString(), "_" });
        }

        /// <summary>
        /// Converts the objects to an sql string representation
        /// </summary>
        /// <param name="criteria">The criteria being used in the query</param>
        /// <param name="criteriaQuery">The criteria query</param>
        /// <param name="enabledFilters">List of enabled filters</param>
        /// <returns>The calculation as an sql string</returns>
        public override SqlString ToGroupSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            var sb = new StringBuilder();

            return new SqlString(new object[] { sb.ToString() });
        }

        /// <summary>
        /// Returns the string symbol of calculation type
        /// </summary>
        /// <param name="type">The type to use</param>
        /// <returns>The string representation</returns>
        private static string TypeToString(CalculationType type)
        {
            switch (type)
            {
                case CalculationType.Addition: return "+";
                case CalculationType.Subtraction: return "-";
                case CalculationType.Multiplication: return "*";
                case CalculationType.Division: return "/";
                default: return "+";
            }
        }
    }
}

