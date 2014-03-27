
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NHibernate.Cache;
using NHibernate.Engine;
using NHibernate.Mapping;
using NHibernate.SqlCommand;
using NHibernate.Type;
using NHibernate.Util;
using NHibernate.Persister.Entity;
using NHibernate;
using NHibernate.Metadata;
using NHibernate.Intercept;
using NHibernate.Id;
using NHibernate.Tuple.Entity;
using NHibernate.Loader.Entity;
namespace MsdLib.DALCore
{
    //Error	15	'MsdLib.DALCore.MsdSingleTableEntityPersister' does not implement inherited abstract member 'NHibernate.Persister.Entity.AbstractEntityPersister.PropertyTableNumbersInSelect.get'	D:\irerp\MsdLib\DALCore\MsdSingleTableEntityPersister.cs	21	19	MsdLib
    //Error	13	'MsdLib.DALCore.MsdSingleTableEntityPersister' does not implement inherited abstract member 'NHibernate.Persister.Entity.AbstractEntityPersister.TableName.get'	D:\irerp\MsdLib\DALCore\MsdSingleTableEntityPersister.cs	24	19	MsdLib
    //Error	14	'MsdLib.DALCore.MsdSingleTableEntityPersister' does not implement inherited abstract member 'NHibernate.Persister.Entity.AbstractEntityPersister.TableSpan.get'	D:\irerp\MsdLib\DALCore\MsdSingleTableEntityPersister.cs	25	19	MsdLib
    //Error	16	'MsdLib.DALCore.MsdSingleTableEntityPersister.PropertyTableNumbersInSelect': cannot change access modifiers when overriding 'protected' inherited member 'NHibernate.Persister.Entity.AbstractEntityPersister.PropertyTableNumbersInSelect'	D:\irerp\MsdLib\DALCore\MsdSingleTableEntityPersister.cs	53	43	MsdLib



    public  class MsdSingleTableEntityPersister : NHibernate.Persister.Entity.AbstractEntityPersister,NHibernate.Persister.Entity.IQueryable
    {
        private readonly Dictionary<string, IUniqueEntityLoader> loaders = new Dictionary<string, IUniqueEntityLoader>();
        public virtual string[] SubclassClosure
        {
            get { return subclassClosure; }
        }
        protected bool IsDiscriminatorFormula
        {
            get { return discriminatorColumnName == null; }
        }
        private bool NeedsDiscriminator
        {
            get { return forceDiscriminator || IsInherited; }
        }
        protected override int TableSpan
        {
            get { return joinSpan; }
        }
        public override string TableName
        {
            get { return qualifiedTableNames[0]; }
        }
        protected override int[] PropertyTableNumbersInSelect
        {
            get { return propertyTableNumbers; }
        }

        protected override int SubclassTableSpan
        {
            get { return subclassTableNameClosure.Length; }
        }
        protected override int[] SubclassFormulaTableNumberClosure
        {
            get { return subclassFormulaTableNumberClosure; }
        }
        protected override int[] SubclassColumnTableNumberClosure
        {
            get { return subclassColumnTableNumberClosure; }
        }
     

        public override string[] PropertySpaces
        {
            get { return spaces; }
        }
        protected override bool IsTableCascadeDeleteEnabled(int j)
        {
            return cascadeDeleteEnabled[j];
        }

        protected override bool IsPropertyOfTable(int property, int table)
        {
            return propertyTableNumbers[property] == table;
        }

        protected override bool IsClassOrSuperclassTable(int j)
        {
            return isClassOrSuperclassTable[j];
        }


        protected override string GetTableName(int table)
        {
            return qualifiedTableNames[table];
        }

        public override string GetSubclassTableName(int j)
        {
            return subclassTableNameClosure[j];
        }
        protected override string[] GetSubclassTableKeyColumns(int j)
        {
            return subclassTableKeyColumnClosure[j];
        }
        protected override int GetSubclassPropertyTableNumber(int i)
        {
            return subclassPropertyTableNumberClosure[i];
        }

        public override string GetSubclassPropertyTableName(int i)
        {
            return subclassTableNameClosure[subclassPropertyTableNumberClosure[i]];
        }

        public override string GetSubclassForDiscriminatorValue(object value)
        {
            string result;
            if (value == null)
            {
                subclassesByDiscriminatorValue.TryGetValue(NullDiscriminator, out result);
            }
            else
            {
                if (!subclassesByDiscriminatorValue.TryGetValue(value, out result))
                    subclassesByDiscriminatorValue.TryGetValue(NotNullDiscriminator, out result);
            }
            return result;
        }
        public override string GetPropertyTableName(string propertyName)
        {
            int? index = EntityMetamodel.GetPropertyIndexOrNull(propertyName);
            if (!index.HasValue) return null;
            return qualifiedTableNames[propertyTableNumbers[index.Value]];
        }

        private string DiscriminatorFilterFragment(string alias)
        {
            const string abstractClassWithNoSubclassExceptionMessageTemplate =
@"The class {0} can't be instatiated and does not have mapped subclasses; 
possible solutions:
- don't map the abstract class
- map the its subclasses.";

            if (NeedsDiscriminator)
            {
                InFragment frag = new InFragment();

                if (IsDiscriminatorFormula)
                {
                    frag.SetFormula(alias, DiscriminatorFormulaTemplate);
                }
                else
                {
                    frag.SetColumn(alias, DiscriminatorColumnName);
                }

                string[] subclasses = SubclassClosure;
                int validValuesForInFragment = 0;
                foreach (string t in subclasses)
                {
                    var queryable = (NHibernate.Persister.Entity.IQueryable)Factory.GetEntityPersister(t);
                    if (!queryable.IsAbstract)
                    {
                        frag.AddValue(queryable.DiscriminatorSQLValue);
                        validValuesForInFragment++;
                    }
                }
                if (validValuesForInFragment == 0)
                {
                    throw new NotSupportedException(string.Format(abstractClassWithNoSubclassExceptionMessageTemplate, subclasses[0]));
                }
                StringBuilder buf = new StringBuilder(50).Append(" and ").Append(frag.ToFragmentString().ToString());

                return buf.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public override string FromTableFragment(string name)
        {
            return TableName + ' ' + name;
        }
        public override string FilterFragment(string alias)
        {
            string result = DiscriminatorFilterFragment(alias);
            if (HasWhere)
                result += " and " + GetSQLWhereString(alias);

            return result;
        }
        protected override string[] GetKeyColumns(int table)
        {
            return keyColumnNames[table];
        }
        public override string DiscriminatorSQLValue
        {
            get { return discriminatorSQLValue; }
        }

        public override object DiscriminatorValue
        {
            get { return discriminatorValue; }
        }
        public override IType DiscriminatorType
        {
            get { return discriminatorType; }
        }
      
        public override string[][] ContraintOrderedTableKeyColumnClosure
        {
            get { return constraintOrderedKeyColumnNames; }
        }
        protected override int[] PropertyTableNumbers
        {
            get { return propertyTableNumbers; }
        }
      
        public override string[] ConstraintOrderedTableNameClosure
        {
            get { return constraintOrderedTableNames; }
        }
        // the class hierarchy structure
        private readonly int joinSpan;
        private readonly string[] qualifiedTableNames;
        private readonly bool[] isInverseTable;
        private readonly bool[] isNullableTable;
        private readonly string[][] keyColumnNames;
        private readonly bool[] cascadeDeleteEnabled;
        private readonly bool hasSequentialSelects;
        private readonly string[] spaces;
        private readonly string[] subclassClosure;
        private readonly string[] subclassTableNameClosure;
        private readonly bool[] subclassTableIsLazyClosure;
        private readonly bool[] isInverseSubclassTable;
        private readonly bool[] isNullableSubclassTable;
        private readonly bool[] subclassTableSequentialSelect;
        private readonly string[][] subclassTableKeyColumnClosure;
        private readonly bool[] isClassOrSuperclassTable;

        // properties of this class, including inherited properties
        private readonly int[] propertyTableNumbers;

        // the closure of all columns used by the entire hierarchy including
        // subclasses and superclasses of this class
        private readonly int[] subclassPropertyTableNumberClosure;

        private readonly int[] subclassColumnTableNumberClosure;
        private readonly int[] subclassFormulaTableNumberClosure;

        // discriminator column
        private readonly Dictionary<object, string> subclassesByDiscriminatorValue = new Dictionary<object, string>();
        private readonly bool forceDiscriminator;
        private readonly string discriminatorColumnName;
        private readonly string discriminatorFormula;
        private readonly string discriminatorFormulaTemplate;
        private readonly string discriminatorAlias;
        private readonly IType discriminatorType;
        private readonly string discriminatorSQLValue;
        private readonly object discriminatorValue;
        private readonly bool discriminatorInsertable;

        private readonly string[] constraintOrderedTableNames;
        private readonly string[][] constraintOrderedKeyColumnNames;

        //private readonly IDictionary propertyTableNumbersByName = new Hashtable();
        private readonly Dictionary<string, int> propertyTableNumbersByNameAndSubclass = new Dictionary<string, int>();

        private readonly Dictionary<string, SqlString> sequentialSelectStringsByEntityName = new Dictionary<string, SqlString>();

        private static readonly object NullDiscriminator = new object();
        private static readonly object NotNullDiscriminator = new object();
        private string[] propertySubclassNames;
        public MsdSingleTableEntityPersister(
            PersistentClass persistentClass, 
            ICacheConcurrencyStrategy cache,
            ISessionFactoryImplementor factory, 
            IMapping mapping)
            : base(persistentClass, cache, factory)
        {
            int hydrateSpan = EntityMetamodel.PropertySpan;
            propertySubclassNames = new string[hydrateSpan];

            #region CLASS + TABLE
            
            joinSpan = persistentClass.JoinClosureSpan + 1;
            qualifiedTableNames = new string[joinSpan];
            isInverseTable = new bool[joinSpan];
            isNullableTable = new bool[joinSpan];
            keyColumnNames = new string[joinSpan][];
            Table table = persistentClass.RootTable;
            qualifiedTableNames[0] =
                table.GetQualifiedName(factory.Dialect, factory.Settings.DefaultCatalogName, factory.Settings.DefaultSchemaName);
            isInverseTable[0] = false;
            isNullableTable[0] = false;
            keyColumnNames[0] = IdentifierColumnNames;
            cascadeDeleteEnabled = new bool[joinSpan];

            // Custom sql
            customSQLInsert = new SqlString[joinSpan];
            customSQLUpdate = new SqlString[joinSpan];
            customSQLDelete = new SqlString[joinSpan];
            insertCallable = new bool[joinSpan];
            updateCallable = new bool[joinSpan];
            deleteCallable = new bool[joinSpan];
            insertResultCheckStyles = new ExecuteUpdateResultCheckStyle[joinSpan];
            updateResultCheckStyles = new ExecuteUpdateResultCheckStyle[joinSpan];
            deleteResultCheckStyles = new ExecuteUpdateResultCheckStyle[joinSpan];

            customSQLInsert[0] = persistentClass.CustomSQLInsert;
            insertCallable[0] = customSQLInsert[0] != null && persistentClass.IsCustomInsertCallable;
            insertResultCheckStyles[0] = persistentClass.CustomSQLInsertCheckStyle
                                                                     ?? ExecuteUpdateResultCheckStyle.DetermineDefault(customSQLInsert[0], insertCallable[0]);
            customSQLUpdate[0] = persistentClass.CustomSQLUpdate;
            updateCallable[0] = customSQLUpdate[0] != null && persistentClass.IsCustomUpdateCallable;
            updateResultCheckStyles[0] = persistentClass.CustomSQLUpdateCheckStyle
                                                                     ?? ExecuteUpdateResultCheckStyle.DetermineDefault(customSQLUpdate[0], updateCallable[0]);
            customSQLDelete[0] = persistentClass.CustomSQLDelete;
            deleteCallable[0] = customSQLDelete[0] != null && persistentClass.IsCustomDeleteCallable;
            deleteResultCheckStyles[0] = persistentClass.CustomSQLDeleteCheckStyle
                                                                     ?? ExecuteUpdateResultCheckStyle.DetermineDefault(customSQLDelete[0], deleteCallable[0]);

            #endregion

            #region JOINS
            int j = 1;
            foreach (Join join in persistentClass.JoinClosureIterator)
            {
                qualifiedTableNames[j] = join.Table.GetQualifiedName(factory.Dialect, factory.Settings.DefaultCatalogName, factory.Settings.DefaultSchemaName);
                isInverseTable[j] = join.IsInverse;
                isNullableTable[j] = join.IsOptional;
                cascadeDeleteEnabled[j] = join.Key.IsCascadeDeleteEnabled && factory.Dialect.SupportsCascadeDelete;

                customSQLInsert[j] = join.CustomSQLInsert;
                insertCallable[j] = customSQLInsert[j] != null && join.IsCustomInsertCallable;
                insertResultCheckStyles[j] = join.CustomSQLInsertCheckStyle
                                                                         ??
                                                                         ExecuteUpdateResultCheckStyle.DetermineDefault(customSQLInsert[j], insertCallable[j]);
                customSQLUpdate[j] = join.CustomSQLUpdate;
                updateCallable[j] = customSQLUpdate[j] != null && join.IsCustomUpdateCallable;
                updateResultCheckStyles[j] = join.CustomSQLUpdateCheckStyle
                                                                         ??
                                                                         ExecuteUpdateResultCheckStyle.DetermineDefault(customSQLUpdate[j], updateCallable[j]);
                customSQLDelete[j] = join.CustomSQLDelete;
                deleteCallable[j] = customSQLDelete[j] != null && join.IsCustomDeleteCallable;
                deleteResultCheckStyles[j] = join.CustomSQLDeleteCheckStyle
                                                                         ??
                                                                         ExecuteUpdateResultCheckStyle.DetermineDefault(customSQLDelete[j], deleteCallable[j]);

                keyColumnNames[j] = join.Key.ColumnIterator.OfType<Column>().Select(col => col.GetQuotedName(factory.Dialect)).ToArray();

                j++;
            }

            constraintOrderedTableNames = new string[qualifiedTableNames.Length];
            constraintOrderedKeyColumnNames = new string[qualifiedTableNames.Length][];
            for (int i = qualifiedTableNames.Length - 1, position = 0; i >= 0; i--, position++)
            {
                constraintOrderedTableNames[position] = qualifiedTableNames[i];
                constraintOrderedKeyColumnNames[position] = keyColumnNames[i];
            }

            spaces = qualifiedTableNames.Concat(persistentClass.SynchronizedTables).ToArray();

            bool lazyAvailable = IsInstrumented(EntityMode.Poco);

            bool hasDeferred = false;
            List<string> subclassTables = new List<string>();
            List<string[]> joinKeyColumns = new List<string[]>();
            List<bool> isConcretes = new List<bool>();
            List<bool> isDeferreds = new List<bool>();
            List<bool> isInverses = new List<bool>();
            List<bool> isNullables = new List<bool>();
            List<bool> isLazies = new List<bool>();
            subclassTables.Add(qualifiedTableNames[0]);
            joinKeyColumns.Add(IdentifierColumnNames);
            isConcretes.Add(true);
            isDeferreds.Add(false);
            isInverses.Add(false);
            isNullables.Add(false);
            isLazies.Add(false);
            foreach (Join join in persistentClass.SubclassJoinClosureIterator)
            {
                isConcretes.Add(persistentClass.IsClassOrSuperclassJoin(join));
                isDeferreds.Add(join.IsSequentialSelect);
                isInverses.Add(join.IsInverse);
                isNullables.Add(join.IsOptional);
                isLazies.Add(lazyAvailable && join.IsLazy);
                if (join.IsSequentialSelect && !persistentClass.IsClassOrSuperclassJoin(join))
                    hasDeferred = true;
                subclassTables.Add(join.Table.GetQualifiedName(factory.Dialect, factory.Settings.DefaultCatalogName, factory.Settings.DefaultSchemaName));

                var keyCols = join.Key.ColumnIterator.OfType<Column>().Select(col => col.GetQuotedName(factory.Dialect)).ToArray();
                joinKeyColumns.Add(keyCols);
            }

            subclassTableSequentialSelect = isDeferreds.ToArray();
            subclassTableNameClosure = subclassTables.ToArray();
            subclassTableIsLazyClosure = isLazies.ToArray();
            subclassTableKeyColumnClosure = joinKeyColumns.ToArray();
            isClassOrSuperclassTable = isConcretes.ToArray();
            isInverseSubclassTable = isInverses.ToArray();
            isNullableSubclassTable = isNullables.ToArray();
            hasSequentialSelects = hasDeferred;

            #endregion

            #region DISCRIMINATOR

            if (persistentClass.IsPolymorphic)
            {
                IValue discrimValue = persistentClass.Discriminator;
                if (discrimValue == null)
                    throw new MappingException("Discriminator mapping required for single table polymorphic persistence");

                forceDiscriminator = persistentClass.IsForceDiscriminator;
                IEnumerator<ISelectable> iSel = discrimValue.ColumnIterator.GetEnumerator();
                iSel.MoveNext();
                ISelectable selectable = iSel.Current;
                if (discrimValue.HasFormula)
                {
                    Formula formula = (Formula)selectable;
                    discriminatorFormula = formula.FormulaString;
                    discriminatorFormulaTemplate = formula.GetTemplate(factory.Dialect, factory.SQLFunctionRegistry);
                    discriminatorColumnName = null;
                    discriminatorAlias = Discriminator_Alias;
                }
                else
                {
                    Column column = (Column)selectable;
                    discriminatorColumnName = column.GetQuotedName(factory.Dialect);
                    discriminatorAlias = column.GetAlias(factory.Dialect, persistentClass.RootTable);
                    discriminatorFormula = null;
                    discriminatorFormulaTemplate = null;
                }
                discriminatorType = persistentClass.Discriminator.Type;
                if (persistentClass.IsDiscriminatorValueNull)
                {
                    discriminatorValue = NullDiscriminator;
                    discriminatorSQLValue = InFragment.Null;
                    discriminatorInsertable = false;
                }
                else if (persistentClass.IsDiscriminatorValueNotNull)
                {
                    discriminatorValue = NotNullDiscriminator;
                    discriminatorSQLValue = InFragment.NotNull;
                    discriminatorInsertable = false;
                }
                else
                {
                    discriminatorInsertable = persistentClass.IsDiscriminatorInsertable && !discrimValue.HasFormula;
                    try
                    {
                        IDiscriminatorType dtype = (IDiscriminatorType)discriminatorType;
                        discriminatorValue = dtype.StringToObject(persistentClass.DiscriminatorValue);
                        discriminatorSQLValue = dtype.ObjectToSQLString(discriminatorValue, factory.Dialect);
                    }
                    catch (InvalidCastException cce)
                    {
                        throw new MappingException(
                            string.Format("Illegal discriminator type: {0} of entity {1}", discriminatorType.Name, persistentClass.EntityName), cce);
                    }
                    catch (Exception e)
                    {
                        throw new MappingException("Could not format discriminator value to SQL string of entity " + persistentClass.EntityName, e);
                    }
                }
            }
            else
            {
                forceDiscriminator = false;
                discriminatorInsertable = false;
                discriminatorColumnName = null;
                discriminatorAlias = null;
                discriminatorType = null;
                discriminatorValue = null;
                discriminatorSQLValue = null;
                discriminatorFormula = null;
                discriminatorFormulaTemplate = null;
            }

            #endregion

            #region PROPERTIES

            propertyTableNumbers = new int[PropertySpan];
            int i2 = 0;
            foreach (Property prop in persistentClass.PropertyClosureIterator)
            {
                propertyTableNumbers[i2++] = persistentClass.GetJoinNumber(prop);
            }

            List<int> columnJoinNumbers = new List<int>();
            List<int> formulaJoinedNumbers = new List<int>();
            List<int> propertyJoinNumbers = new List<int>();
            foreach (Property prop in persistentClass.SubclassPropertyClosureIterator)
            {
                int join = persistentClass.GetJoinNumber(prop);
                propertyJoinNumbers.Add(join);

                propertyTableNumbersByNameAndSubclass[prop.PersistentClass.EntityName + '.' + prop.Name] = join;
                foreach (ISelectable thing in prop.ColumnIterator)
                {
                    if (thing.IsFormula)
                        formulaJoinedNumbers.Add(join);
                    else
                        columnJoinNumbers.Add(join);
                }
            }

            subclassColumnTableNumberClosure = columnJoinNumbers.ToArray();
            subclassFormulaTableNumberClosure = formulaJoinedNumbers.ToArray();
            subclassPropertyTableNumberClosure = propertyJoinNumbers.ToArray();

            int subclassSpan = persistentClass.SubclassSpan + 1;
            subclassClosure = new string[subclassSpan];
            subclassClosure[0] = EntityName;
            if (persistentClass.IsPolymorphic)
                subclassesByDiscriminatorValue[discriminatorValue] = EntityName;

            #endregion

            #region SUBCLASSES
            if (persistentClass.IsPolymorphic)
            {
                int k = 1;
                foreach (Subclass sc in persistentClass.SubclassIterator)
                {
                    subclassClosure[k++] = sc.EntityName;
                    if (sc.IsDiscriminatorValueNull)
                    {
                        subclassesByDiscriminatorValue[NullDiscriminator] = sc.EntityName;
                    }
                    else if (sc.IsDiscriminatorValueNotNull)
                    {
                        subclassesByDiscriminatorValue[NotNullDiscriminator] = sc.EntityName;
                    }
                    else
                    {
                        if (discriminatorType == null)
                            throw new MappingException("Not available discriminator type of entity " + persistentClass.EntityName);
                        try
                        {
                            IDiscriminatorType dtype = (IDiscriminatorType)discriminatorType;
                            subclassesByDiscriminatorValue[dtype.StringToObject(sc.DiscriminatorValue)] = sc.EntityName;
                        }
                        catch (InvalidCastException cce)
                        {
                            throw new MappingException(
                                string.Format("Illegal discriminator type: {0} of entity {1}", discriminatorType.Name, persistentClass.EntityName), cce);
                        }
                        catch (Exception e)
                        {
                            throw new MappingException("Error parsing discriminator value of entity " + persistentClass.EntityName, e);
                        }
                    }
                }
            }

            #endregion

            InitLockers();

            InitSubclassPropertyAliasesMap(persistentClass);

            PostConstruct(mapping);
            
        }


        public override string DiscriminatorColumnName
        {
            get { return discriminatorColumnName; }
        }
        #region "IQueryable"

        string NHibernate.Persister.Entity.IQueryable.DiscriminatorSQLValue
        {
            get { return discriminatorSQLValue; }
        }

        object NHibernate.Persister.Entity.IQueryable.DiscriminatorValue
        {
            get { return discriminatorValue; }
        }

        bool NHibernate.Persister.Entity.IQueryable.IsMultiTable
        {
            get { return TableSpan > 1; }
        }

        string[] NHibernate.Persister.Entity.IQueryable.ConstraintOrderedTableNameClosure
        {
            get { return constraintOrderedTableNames; }
        }

        string[][] NHibernate.Persister.Entity.IQueryable.ContraintOrderedTableKeyColumnClosure
        {
            get { return constraintOrderedKeyColumnNames; }
        }

        public int GetSubclassPropertyTableNumber(string propertyName, string entityName)
        {
            IType type = propertyMapping.ToType(propertyName);
            if (type.IsAssociationType && ((IAssociationType)type).UseLHSPrimaryKey)
                return 0;
            int tabnum;
            propertyTableNumbersByNameAndSubclass.TryGetValue(entityName + '.' + propertyName, out tabnum);
            return tabnum;
        }
  


        string NHibernate.Persister.Entity.IQueryable.GetSubclassTableName(int j)
        {
            return subclassTableNameClosure[j];
        }

        IType ILoadable.DiscriminatorType
        {
            get { return discriminatorType; }
        }

        string ILoadable.DiscriminatorColumnName
        {
            get { return discriminatorColumnName; }
        }

        string ILoadable.GetSubclassForDiscriminatorValue(object value)
        {
            string result;
            if (value == null)
            {
                subclassesByDiscriminatorValue.TryGetValue(NullDiscriminator, out result);
            }
            else
            {
                if (!subclassesByDiscriminatorValue.TryGetValue(value, out result))
                    subclassesByDiscriminatorValue.TryGetValue(NotNullDiscriminator, out result);
            }
            return result;
        }
  
        object[] ILoadable.Hydrate(System.Data.IDataReader rs, object id, object obj, ILoadable rootLoadable, string[][] suffixedPropertyColumns, bool allProperties, ISessionImplementor session)
        {
            return base.Hydrate(rs, id, obj, rootLoadable, suffixedPropertyColumns, allProperties, session);
        }

        ISessionFactoryImplementor IEntityPersister.Factory
        {
            get { return base.Factory; }
        }

        string IEntityPersister.RootEntityName
        {
            get { return base.RootEntityName; }
        }

        string IEntityPersister.EntityName
        {
            get { return base.EntityName; }
        }

        EntityMetamodel IEntityPersister.EntityMetamodel
        {
            get { return base.EntityMetamodel; }
        }

        string[] IEntityPersister.PropertySpaces
        {
            get { return spaces; }
        }

        string[] IEntityPersister.QuerySpaces
        {
            get { return base.QuerySpaces; }
        }

        bool IEntityPersister.IsMutable
        {
            get { return base.IsMutable; }
        }

        bool IEntityPersister.IsInherited
        {
            get { return base.IsInherited; }
        }

        bool IEntityPersister.IsIdentifierAssignedByInsert
        {
            get { return base.IsIdentifierAssignedByInsert; }
        }

        bool IEntityPersister.IsVersioned
        {
            get { return base.IsVersioned; }
        }

        IVersionType IEntityPersister.VersionType
        {
            get { return VersionType; }
        }

        int IEntityPersister.VersionProperty
        {
            get { return base.VersionProperty; }
        }

        int[] IEntityPersister.NaturalIdentifierProperties
        {
            get { return base.NaturalIdentifierProperties; }
        }

        IIdentifierGenerator IEntityPersister.IdentifierGenerator
        {
            get { return base.IdentifierGenerator; }
        }

        IType[] IEntityPersister.PropertyTypes
        {
            get { return base.PropertyTypes; }
        }

        string[] IEntityPersister.PropertyNames
        {
            get { return base.PropertyNames; }
        }

        bool[] IEntityPersister.PropertyInsertability
        {
            get { return base.PropertyInsertability; }
        }

        ValueInclusion[] IEntityPersister.PropertyInsertGenerationInclusions
        {
            get { return base.PropertyInsertGenerationInclusions; }
        }

        ValueInclusion[] IEntityPersister.PropertyUpdateGenerationInclusions
        {
            get { return base.PropertyUpdateGenerationInclusions; }
        }

        bool[] IEntityPersister.PropertyCheckability
        {
            get { return base.PropertyCheckability; }
        }

        bool[] IEntityPersister.PropertyNullability
        {
            get { return base.PropertyNullability; }
        }

        bool[] IEntityPersister.PropertyVersionability
        {
            get { return base.PropertyVersionability; }
        }

        bool[] IEntityPersister.PropertyLaziness
        {
            get { return base.PropertyLaziness; }
        }

        CascadeStyle[] IEntityPersister.PropertyCascadeStyles
        {
            get { return base.PropertyCascadeStyles; }
        }

        IType IEntityPersister.IdentifierType
        {
            get { return base.IdentifierType; }
        }

        string IEntityPersister.IdentifierPropertyName
        {
            get { return base.IdentifierPropertyName; }
        }

        bool IEntityPersister.IsCacheInvalidationRequired
        {
            get { return base.IsCacheInvalidationRequired; }
        }

        bool IEntityPersister.IsLazyPropertiesCacheable
        {
            get { return base.IsLazyPropertiesCacheable; }
        }

        ICacheConcurrencyStrategy IEntityPersister.Cache
        {
            get { return base.Cache; }
        }

        NHibernate.Cache.Entry.ICacheEntryStructure IEntityPersister.CacheEntryStructure
        {
            get { return base.CacheEntryStructure; }
        }

        IClassMetadata IEntityPersister.ClassMetadata
        {
            get { return base.ClassMetadata; }
        }

        bool IEntityPersister.IsBatchLoadable
        {
            get { return base.IsBatchLoadable; }
        }

        bool IEntityPersister.IsSelectBeforeUpdateRequired
        {
            get { return base.IsSelectBeforeUpdateRequired; }
        }

        bool IEntityPersister.IsVersionPropertyGenerated
        {
            get { return base.IsVersionPropertyGenerated; }
        }
        private SqlString GenerateSequentialSelect(ILoadable persister)
        {
            
            //note that this method could easily be moved up to BasicEntityPersister,
            //if we ever needed to reuse it from other subclasses

            //figure out which tables need to be fetched (only those that contains at least a no-lazy-property)
            AbstractEntityPersister subclassPersister = (AbstractEntityPersister)persister;
            var tableNumbers = new HashSet<int>();
            string[] props = subclassPersister.PropertyNames;
            string[] classes = propertySubclassNames;
            for (int i = 0; i < props.Length; i++)
            {
                int propTableNumber = GetSubclassPropertyTableNumber(props[i], classes[i]);
                if (IsSubclassTableSequentialSelect(propTableNumber) && !IsSubclassTableLazy(propTableNumber))
                {
                    tableNumbers.Add(propTableNumber);
                }
            }
            if ((tableNumbers.Count == 0))
                return null;

            //figure out which columns are needed (excludes lazy-properties)
            List<int> columnNumbers = new List<int>();
            int[] columnTableNumbers = SubclassColumnTableNumberClosure;
            for (int i = 0; i < SubclassColumnClosure.Length; i++)
            {
                if (tableNumbers.Contains(columnTableNumbers[i]))
                {
                    columnNumbers.Add(i);
                }
            }

            //figure out which formulas are needed (excludes lazy-properties)
            List<int> formulaNumbers = new List<int>();
            int[] formulaTableNumbers = SubclassColumnTableNumberClosure;
            for (int i = 0; i < SubclassFormulaTemplateClosure.Length; i++)
            {
                if (tableNumbers.Contains(formulaTableNumbers[i]))
                {
                    formulaNumbers.Add(i);
                }
            }

            //render the SQL
            return RenderSelect(tableNumbers.ToArray(), columnNumbers.ToArray(), formulaNumbers.ToArray());
        }
        void IEntityPersister.PostInstantiate()
        {
            base.PostInstantiate();
            if (hasSequentialSelects)
            {
                string[] entityNames = SubclassClosure;
                for (int i = 1; i < entityNames.Length; i++)
                {
                    ILoadable loadable = (ILoadable)Factory.GetEntityPersister(entityNames[i]);
                    if (!loadable.IsAbstract)
                    {
                        //perhaps not really necessary...
                        SqlString sequentialSelect = GenerateSequentialSelect(loadable);
                        sequentialSelectStringsByEntityName[entityNames[i]] = sequentialSelect;
                    }
                }
            }
        }

        bool IEntityPersister.IsSubclassEntityName(string entityName)
        {
            return base.IsSubclassEntityName(entityName);
        }

        bool IEntityPersister.HasProxy
        {
            get { return base.HasProxy; }
        }

        bool IEntityPersister.HasCollections
        {
            get { return base.HasCollections; }
        }

        bool IEntityPersister.HasMutableProperties
        {
            get { return base.HasMutableProperties; }
        }

        bool IEntityPersister.HasSubselectLoadableCollections
        {
            get { return base.HasSubselectLoadableCollections; }
        }

        bool IEntityPersister.HasCascades
        {
            get { return base.HasCascades; }
        }

        IType IEntityPersister.GetPropertyType(string propertyName)
        {
            return base.GetPropertyType(propertyName);
        }

        int[] IEntityPersister.FindDirty(object[] currentState, object[] previousState, object entity, ISessionImplementor session)
        {
            return base.FindDirty(currentState, previousState, entity, session);
        }

        int[] IEntityPersister.FindModified(object[] old, object[] current, object entity, ISessionImplementor session)
        {
            return base.FindModified(old, current, entity, session);
        }

        bool IEntityPersister.HasIdentifierProperty
        {
            get { return base.HasIdentifierProperty; }
        }

        bool IEntityPersister.CanExtractIdOutOfEntity
        {
            get { return base.CanExtractIdOutOfEntity; }
        }

        bool IEntityPersister.HasNaturalIdentifier
        {
            get { return base.HasNaturalIdentifier; }
        }

        object[] IEntityPersister.GetNaturalIdentifierSnapshot(object id, ISessionImplementor session)
        {
            return base.GetNaturalIdentifierSnapshot(id, session);
        }

        bool IEntityPersister.HasLazyProperties
        {
            get { return base.HasLazyProperties; }
        }

        object IEntityPersister.Load(object id, object optionalObject, LockMode lockMode, ISessionImplementor session)
        {
            return base.Load(id, optionalObject, lockMode, session);
        }
     
        void IEntityPersister.Lock(object id, object version, object obj, LockMode lockMode, ISessionImplementor session)
        {
            base.Lock(id, version, obj, lockMode, session);
        }

        void IEntityPersister.Insert(object id, object[] fields, object obj, ISessionImplementor session)
        {
            base.Insert(id, fields, obj, session);
        }

        object IEntityPersister.Insert(object[] fields, object obj, ISessionImplementor session)
        {
            return base.Insert(fields, obj, session);
        }

        void IEntityPersister.Delete(object id, object version, object obj, ISessionImplementor session)
        {
            base.Delete(id, version, obj, session);
        }

        void IEntityPersister.Update(object id, object[] fields, int[] dirtyFields, bool hasDirtyCollection, object[] oldFields, object oldVersion, object obj, object rowId, ISessionImplementor session)
        {
            base.Update(id, fields, dirtyFields, hasDirtyCollection, oldFields, oldVersion, obj, rowId, session);
        }

        bool[] IEntityPersister.PropertyUpdateability
        {
            get { return base.PropertyUpdateability; }
        }

        bool IEntityPersister.HasCache
        {
            get { return base.HasCache; }
        }

        object[] IEntityPersister.GetDatabaseSnapshot(object id, ISessionImplementor session)
        {
            return base.GetDatabaseSnapshot(id, session);
        }

        object IEntityPersister.GetCurrentVersion(object id, ISessionImplementor session)
        {
            return base.GetCurrentVersion(id, session);
        }

        object IEntityPersister.ForceVersionIncrement(object id, object currentVersion, ISessionImplementor session)
        {
            return base.ForceVersionIncrement(id, currentVersion, session);
        }

        EntityMode? IEntityPersister.GuessEntityMode(object obj)
        {
            return base.GuessEntityMode(obj);

        }

        bool IEntityPersister.IsInstrumented(EntityMode entityMode)
        {
            return base.IsInstrumented(entityMode);
        }

        bool IEntityPersister.HasInsertGeneratedProperties
        {
            get { return base.HasInsertGeneratedProperties; }
        }

        bool IEntityPersister.HasUpdateGeneratedProperties
        {
            get { return base.HasUpdateGeneratedProperties; }
        }

        void IEntityPersister.AfterInitialize(object entity, bool lazyPropertiesAreUnfetched, ISessionImplementor session)
        {
             base.AfterInitialize(entity, lazyPropertiesAreUnfetched, session);
        }

        void IEntityPersister.AfterReassociate(object entity, ISessionImplementor session)
        {
            base.AfterReassociate(entity, session);
        }

        object IEntityPersister.CreateProxy(object id, ISessionImplementor session)
        {
            return base.CreateProxy(id, session);
        }

        bool? IEntityPersister.IsTransient(object obj, ISessionImplementor session)
        {
            return base.IsTransient(obj, session);
        }

        object[] IEntityPersister.GetPropertyValuesToInsert(object obj, System.Collections.IDictionary mergeMap, ISessionImplementor session)
        {
            return GetPropertyValuesToInsert(obj, mergeMap, session);
        }

        void IEntityPersister.ProcessInsertGeneratedProperties(object id, object entity, object[] state, ISessionImplementor session)
        {
             base.ProcessInsertGeneratedProperties(id, entity, state, session);
        }

        void IEntityPersister.ProcessUpdateGeneratedProperties(object id, object entity, object[] state, ISessionImplementor session)
        {
            base.ProcessUpdateGeneratedProperties(id, entity, state, session);
        }

        Type IEntityPersister.GetMappedClass(EntityMode entityMode)
        {
            return GetMappedClass(entityMode);
        }

        bool IEntityPersister.ImplementsLifecycle(EntityMode entityMode)
        {
            return base.ImplementsLifecycle(entityMode);
        }

        bool IEntityPersister.ImplementsValidatable(EntityMode entityMode)
        {
            return base.ImplementsValidatable(entityMode);
        }

        Type IEntityPersister.GetConcreteProxyClass(EntityMode entityMode)
        {
            return base.GetConcreteProxyClass(entityMode);
        }

        void IEntityPersister.SetPropertyValues(object obj, object[] values, EntityMode entityMode)
        {
             base.SetPropertyValues(obj, values, entityMode);
        }

        void IEntityPersister.SetPropertyValue(object obj, int i, object value, EntityMode entityMode)
        {
            base.SetPropertyValue(obj, i, value, entityMode);
        }

        object[] IEntityPersister.GetPropertyValues(object obj, EntityMode entityMode)
        {
            return base.GetPropertyValues(obj, entityMode);
        }

        object IEntityPersister.GetPropertyValue(object obj, int i, EntityMode entityMode)
        {
            return base.GetPropertyValue(obj, i, entityMode);
        }

        object IEntityPersister.GetPropertyValue(object obj, string name, EntityMode entityMode)
        {
            return base.GetPropertyValue(obj, name, entityMode);
        }

        object IEntityPersister.GetIdentifier(object obj, EntityMode entityMode)
        {
            return base.GetIdentifier(obj, entityMode);
        }

        void IEntityPersister.SetIdentifier(object obj, object id, EntityMode entityMode)
        {
            base.SetIdentifier(obj, id, entityMode);
        }

        object IEntityPersister.GetVersion(object obj, EntityMode entityMode)
        {
            return base.GetVersion(obj, entityMode);
        }

        object IEntityPersister.Instantiate(object id, EntityMode entityMode)
        {
            return base.Instantiate(id, entityMode);
        }

        bool IEntityPersister.IsInstance(object entity, EntityMode entityMode)
        {
            return base.IsInstance(entity, entityMode);
        }

        bool IEntityPersister.HasUninitializedLazyProperties(object obj, EntityMode entityMode)
        {
            return base.HasUninitializedLazyProperties(obj, entityMode);
        }

        void IEntityPersister.ResetIdentifier(object entity, object currentId, object currentVersion, EntityMode entityMode)
        {
            base.ResetIdentifier(entity, currentId, currentVersion, entityMode);
        }

        IEntityPersister IEntityPersister.GetSubclassEntityPersister(object instance, ISessionFactoryImplementor factory, EntityMode entityMode)
        {
            return base.GetSubclassEntityPersister(instance, factory, entityMode);
        }

        bool? IEntityPersister.IsUnsavedVersion(object version)
        {
            return base.IsUnsavedVersion(version);
        }

        bool IOptimisticCacheSource.IsVersioned
        {
            get { return base.IsVersioned; }
        }

        System.Collections.IComparer IOptimisticCacheSource.VersionComparator
        {
            get { return base.VersionComparator; }
        }

        IType IPropertyMapping.Type
        {
            get { return base.Type; }
        }

        IType IPropertyMapping.ToType(string propertyName)
        {
            return base.ToType(propertyName);
        }

        bool IPropertyMapping.TryToType(string propertyName, out IType type)
        {
            return base.TryToType(propertyName, out type);
        }

        string[] IPropertyMapping.ToColumns(string alias, string propertyName)
        {
            return base.ToColumns(alias, propertyName);
        }

        string[] IPropertyMapping.ToColumns(string propertyName)
        {
            return base.ToColumns(propertyName);
        }

        string IJoinable.Name
        {
            get { return base.Name; }
        }

        string[] IJoinable.KeyColumnNames
        {
            get { return base.KeyColumnNames; }
        }

        bool IJoinable.IsCollection
        {
            get { return base.IsCollection; }
        }

        

        string IJoinable.SelectFragment(IJoinable rhs, string rhsAlias, string lhsAlias, string currentEntitySuffix, string currentCollectionSuffix, bool includeCollectionColumns)
        {
            return
                base.SelectFragment(rhs, rhsAlias, lhsAlias, currentEntitySuffix, currentCollectionSuffix, includeCollectionColumns);
        }

        SqlString IJoinable.WhereJoinFragment(string alias, bool innerJoin, bool includeSubclasses)
        {
            return base.WhereJoinFragment(alias, innerJoin, includeSubclasses);
        }

        SqlString IJoinable.FromJoinFragment(string alias, bool innerJoin, bool includeSubclasses)
        {
            return base.FromJoinFragment(alias, innerJoin, includeSubclasses);
        }

        string IJoinable.FilterFragment(string alias, IDictionary<string, IFilter> enabledFilters)
        {
            return base.FilterFragment(alias, enabledFilters);
        }

        string IJoinable.OneToManyFilterFragment(string alias)
        {
            return forceDiscriminator ? DiscriminatorFilterFragment(alias) : string.Empty;
        }

        bool IJoinable.ConsumesEntityAlias()
        {
            return base.ConsumesEntityAlias();
        }

        bool IJoinable.ConsumesCollectionAlias()
        {
            return base.ConsumesCollectionAlias();
        }
        #endregion
    }
   	
}


