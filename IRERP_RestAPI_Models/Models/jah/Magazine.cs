
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
public class Magazine:IRERP_RestAPI.Bases.ModelBaseLog<Magazine, MagazineLog>{
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


                                            LoadableVar<Title> _onvan= new LoadableVar<Title>();
                                            public virtual Title _____onvan { get; set; }
                                            public virtual Title onvan
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Title, Guid>
                                                        (ref _onvan,
                                                        x => x._____onvan,
                                                        ModelRepositories.jah.Title_Repository.ByPK,
                                                        x => x._____onvan.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.onvan, x => x._____onvan, _onvan, value);

                                                }
                                            }
                                    

                                            LoadableVar<MagazineType> _noe_majale= new LoadableVar<MagazineType>();
                                            public virtual MagazineType _____noe_majale { get; set; }
                                            public virtual MagazineType noe_majale
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<MagazineType, Guid>
                                                        (ref _noe_majale,
                                                        x => x._____noe_majale,
                                                        ModelRepositories.jah.MagazineType_Repository.ByPK,
                                                        x => x._____noe_majale.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.noe_majale, x => x._____noe_majale, _noe_majale, value);

                                                }
                                            }
                                    

                                LoadableVar<IList<Magazine_mozuaat>> _mozuaat = new LoadableVar<IList<Magazine_mozuaat>>();
                                public virtual IList<Magazine_mozuaat> _____mozuaat { get; set; }
                                public virtual IList<Magazine_mozuaat> mozuaat
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Magazine_mozuaat, Guid>(ref _mozuaat, x => x._____mozuaat,
                                            ModelRepositories.jah.Magazine_mozuaat_Repository.ListByMagazinePK<Magazine>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Magazine = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.mozuaat, x => x._____mozuaat, _mozuaat, value); }
                                }

                                    

                                LoadableVar<IList<MagazineVersion>> _magver = new LoadableVar<IList<MagazineVersion>>();
                                public virtual IList<MagazineVersion> _____magver { get; set; }
                                public virtual IList<MagazineVersion> magver
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<MagazineVersion, Guid>(ref _magver, x => x._____magver,
                                            ModelRepositories.jah.MagazineVersion_Repository.ListByMagazinePK<Magazine>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Magazine = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.magver, x => x._____magver, _magver, value); }
                                }

                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            


                          if (_GPN(x => x.onvan) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____onvan), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.noe_majale) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____noe_majale), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.mozuaat) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____mozuaat), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.magver) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____magver), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
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
                    
            if (Dic.ContainsKey(_GPN(x => x.onvan.id).ToClientDsFieldName()))
            {
                try
                {
                    this.onvan= ModelRepositories.jah.Title_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.onvan.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.onvan), ref Dic);

                }
                catch { }
            }
                    
            if (Dic.ContainsKey(_GPN(x => x.noe_majale.id).ToClientDsFieldName()))
            {
                try
                {
                    this.noe_majale= ModelRepositories.jah.MagazineType_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.noe_majale.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.noe_majale), ref Dic);

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
                return ModelRepositories.jah.Magazine_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
public class MagazineLog: LogModelBase<MagazineLog>
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


                                            LoadableVar<Title> _onvan= new LoadableVar<Title>();
                                            public virtual Title _____onvan { get; set; }
                                            public virtual Title onvan
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Title, Guid>
                                                        (ref _onvan,
                                                        x => x._____onvan,
                                                        ModelRepositories.jah.Title_Repository.ByPK,
                                                        x => x._____onvan.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.onvan, x => x._____onvan, _onvan, value);

                                                }
                                            }
                                    

                                            LoadableVar<MagazineType> _noe_majale= new LoadableVar<MagazineType>();
                                            public virtual MagazineType _____noe_majale { get; set; }
                                            public virtual MagazineType noe_majale
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<MagazineType, Guid>
                                                        (ref _noe_majale,
                                                        x => x._____noe_majale,
                                                        ModelRepositories.jah.MagazineType_Repository.ByPK,
                                                        x => x._____noe_majale.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.noe_majale, x => x._____noe_majale, _noe_majale, value);

                                                }
                                            }
                                    
}
}

