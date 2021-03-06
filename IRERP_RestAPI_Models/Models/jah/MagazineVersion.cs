
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.DALCore;
using MsdLib.Types;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using MsdLib.ExtentionFuncs.Strings;
using System.Linq;
using IRERP_RestAPI.Models.jah;
namespace IRERP_RestAPI.Models.jah{
public class MagazineVersion:IRERP_RestAPI.Bases.ModelBaseLog<MagazineVersion, MagazineVersionLog>{
public virtual DateTime AddDate { get; set; }

public virtual DateTime LastModifyDate { get; set; }


                                            LoadableVar<User> _AddedBy= new LoadableVar<User>();
                                            public virtual User _____AddedBy { get; set; }
                                            public virtual User AddedBy
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<User, Guid>
                                                        (ref _AddedBy,
                                                        x => x._____AddedBy,
                                                        ModelRepositories.UserRepository.ByPK,
                                                        x => x._____AddedBy.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.AddedBy, x => x._____AddedBy, _AddedBy, value);

                                                }
                                            }
                                    

                                            LoadableVar<User> _ModifyBy= new LoadableVar<User>();
                                            public virtual User _____ModifyBy { get; set; }
                                            public virtual User ModifyBy
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<User, Guid>
                                                        (ref _ModifyBy,
                                                        x => x._____ModifyBy,
                                                        ModelRepositories.UserRepository.ByPK,
                                                        x => x._____ModifyBy.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.ModifyBy, x => x._____ModifyBy, _ModifyBy, value);

                                                }
                                            }
                                    
public virtual string Description { get; set; }

public virtual string shomare { get; set; }

public virtual int tirajh { get; set; }


                                            LoadableVar<Magazine> _Magazine= new LoadableVar<Magazine>();
                                            public virtual Magazine _____Magazine { get; set; }
                                            public virtual Magazine Magazine
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Magazine, Guid>
                                                        (ref _Magazine,
                                                        x => x._____Magazine,
                                                        ModelRepositories.jah.Magazine_Repository.ByPK,
                                                        x => x._____Magazine.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Magazine, x => x._____Magazine, _Magazine, value);

                                                }
                                            }
                                    

                                            LoadableVar<Year> _year= new LoadableVar<Year>();
                                            public virtual Year _____year { get; set; }
                                            public virtual Year year
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Year, Guid>
                                                        (ref _year,
                                                        x => x._____year,
                                                        ModelRepositories.jah.Year_Repository.ByPK,
                                                        x => x._____year.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.year, x => x._____year, _year, value);

                                                }
                                            }
                                    

                                LoadableVar<IList<MagazineVersion_mokhatab>> _mokhatab = new LoadableVar<IList<MagazineVersion_mokhatab>>();
                                public virtual IList<MagazineVersion_mokhatab> _____mokhatab { get; set; }
                                public virtual IList<MagazineVersion_mokhatab> mokhatab
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<MagazineVersion_mokhatab, Guid>(ref _mokhatab, x => x._____mokhatab,
                                            ModelRepositories.jah.MagazineVersion_mokhatab_Repository.ListByMagazineVersionPK<MagazineVersion>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.MagazineVersion = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.mokhatab, x => x._____mokhatab, _mokhatab, value); }
                                }

                                    

                                LoadableVar<IList<MagazineVersion_Ghate>> _Ghate = new LoadableVar<IList<MagazineVersion_Ghate>>();
                                public virtual IList<MagazineVersion_Ghate> _____Ghate { get; set; }
                                public virtual IList<MagazineVersion_Ghate> Ghate
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<MagazineVersion_Ghate, Guid>(ref _Ghate, x => x._____Ghate,
                                            ModelRepositories.jah.MagazineVersion_Ghate_Repository.ListByMagazineVersionPK<MagazineVersion>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.MagazineVersion = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.Ghate, x => x._____Ghate, _Ghate, value); }
                                }

                                    

                                LoadableVar<IList<MagazineVersion_modirmasoul>> _modirmasoul = new LoadableVar<IList<MagazineVersion_modirmasoul>>();
                                public virtual IList<MagazineVersion_modirmasoul> _____modirmasoul { get; set; }
                                public virtual IList<MagazineVersion_modirmasoul> modirmasoul
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<MagazineVersion_modirmasoul, Guid>(ref _modirmasoul, x => x._____modirmasoul,
                                            ModelRepositories.jah.MagazineVersion_modirmasoul_Repository.ListByMagazineVersionPK<MagazineVersion>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.MagazineVersion = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.modirmasoul, x => x._____modirmasoul, _modirmasoul, value); }
                                }

                                    

                                LoadableVar<IList<MagazineVersion_nevisandeh>> _nevisandeh = new LoadableVar<IList<MagazineVersion_nevisandeh>>();
                                public virtual IList<MagazineVersion_nevisandeh> _____nevisandeh { get; set; }
                                public virtual IList<MagazineVersion_nevisandeh> nevisandeh
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<MagazineVersion_nevisandeh, Guid>(ref _nevisandeh, x => x._____nevisandeh,
                                            ModelRepositories.jah.MagazineVersion_nevisandeh_Repository.ListByMagazineVersionPK<MagazineVersion>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.MagazineVersion = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.nevisandeh, x => x._____nevisandeh, _nevisandeh, value); }
                                }

                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            




                          if (_GPN(x => x.Magazine) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Magazine), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.year) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____year), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.mokhatab) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____mokhatab), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.Ghate) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Ghate), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.modirmasoul) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____modirmasoul), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.nevisandeh) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____nevisandeh), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
return base.GetAssociation(PropertyPath);
}
  public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {
         
            if (Dic.ContainsKey(_GPN(x => x.AddedBy.id).ToClientDsFieldName()))
            {
                try
                {
                    this.AddedBy= ModelRepositories.UserRepository.ByPK(Guid.Parse(Dic[_GPN(x => x.AddedBy.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.AddedBy), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.ModifyBy.id).ToClientDsFieldName()))
            {
                try
                {
                    this.ModifyBy= ModelRepositories.UserRepository.ByPK(Guid.Parse(Dic[_GPN(x => x.ModifyBy.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.ModifyBy), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.Magazine.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Magazine= ModelRepositories.jah.Magazine_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.Magazine.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Magazine), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.year.id).ToClientDsFieldName()))
            {
                try
                {
                    this.year= ModelRepositories.jah.Year_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.year.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.year), ref Dic);

                }
                catch { }
            }
                    
                        base.LoadFromStringDictionary(Dic);
            }
  
            public override INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
            {
            if (
                primarykeys_value.Keys.Contains(_GPN(x => x.id))
                && 
                primarykeys_value[_GPN(x => x.id)] != null)
            {
                return ModelRepositories.jah.MagazineVersion_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
public class MagazineVersionLog: LogModelBase<MagazineVersionLog>
                                {
                                public virtual DateTime AddDate { get; set; }

public virtual DateTime LastModifyDate { get; set; }


                                            LoadableVar<User> _AddedBy= new LoadableVar<User>();
                                            public virtual User _____AddedBy { get; set; }
                                            public virtual User AddedBy
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<User, Guid>
                                                        (ref _AddedBy,
                                                        x => x._____AddedBy,
                                                        ModelRepositories.UserRepository.ByPK,
                                                        x => x._____AddedBy.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.AddedBy, x => x._____AddedBy, _AddedBy, value);

                                                }
                                            }
                                    

                                            LoadableVar<User> _ModifyBy= new LoadableVar<User>();
                                            public virtual User _____ModifyBy { get; set; }
                                            public virtual User ModifyBy
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<User, Guid>
                                                        (ref _ModifyBy,
                                                        x => x._____ModifyBy,
                                                        ModelRepositories.UserRepository.ByPK,
                                                        x => x._____ModifyBy.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.ModifyBy, x => x._____ModifyBy, _ModifyBy, value);

                                                }
                                            }
                                    
public virtual string Description { get; set; }

public virtual string shomare { get; set; }

public virtual int tirajh { get; set; }


                                            LoadableVar<Magazine> _Magazine= new LoadableVar<Magazine>();
                                            public virtual Magazine _____Magazine { get; set; }
                                            public virtual Magazine Magazine
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Magazine, Guid>
                                                        (ref _Magazine,
                                                        x => x._____Magazine,
                                                        ModelRepositories.jah.Magazine_Repository.ByPK,
                                                        x => x._____Magazine.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Magazine, x => x._____Magazine, _Magazine, value);

                                                }
                                            }
                                    

                                            LoadableVar<Year> _year= new LoadableVar<Year>();
                                            public virtual Year _____year { get; set; }
                                            public virtual Year year
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Year, Guid>
                                                        (ref _year,
                                                        x => x._____year,
                                                        ModelRepositories.jah.Year_Repository.ByPK,
                                                        x => x._____year.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.year, x => x._____year, _year, value);

                                                }
                                            }
                                    
}
}

