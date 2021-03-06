
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
public class Media:IRERP_RestAPI.Bases.ModelBaseLog<Media, MediaLog>{
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

public virtual int tedad_barnameh { get; set; }

public virtual string shomareh { get; set; }


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
                                    

                                            LoadableVar<TVRD> _tv_rd= new LoadableVar<TVRD>();
                                            public virtual TVRD _____tv_rd { get; set; }
                                            public virtual TVRD tv_rd
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<TVRD, Guid>
                                                        (ref _tv_rd,
                                                        x => x._____tv_rd,
                                                        ModelRepositories.jah.TVRD_Repository.ByPK,
                                                        x => x._____tv_rd.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.tv_rd, x => x._____tv_rd, _tv_rd, value);

                                                }
                                            }
                                    

                                LoadableVar<IList<Media_mozuaat>> _mozuaat = new LoadableVar<IList<Media_mozuaat>>();
                                public virtual IList<Media_mozuaat> _____mozuaat { get; set; }
                                public virtual IList<Media_mozuaat> mozuaat
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Media_mozuaat, Guid>(ref _mozuaat, x => x._____mozuaat,
                                            ModelRepositories.jah.Media_mozuaat_Repository.ListByMediaPK<Media>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Media = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.mozuaat, x => x._____mozuaat, _mozuaat, value); }
                                }

                                    

                                LoadableVar<IList<Media_sathe_mokhatab>> _sathe_mokhatab = new LoadableVar<IList<Media_sathe_mokhatab>>();
                                public virtual IList<Media_sathe_mokhatab> _____sathe_mokhatab { get; set; }
                                public virtual IList<Media_sathe_mokhatab> sathe_mokhatab
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Media_sathe_mokhatab, Guid>(ref _sathe_mokhatab, x => x._____sathe_mokhatab,
                                            ModelRepositories.jah.Media_sathe_mokhatab_Repository.ListByMediaPK<Media>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Media = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.sathe_mokhatab, x => x._____sathe_mokhatab, _sathe_mokhatab, value); }
                                }

                                    

                                LoadableVar<IList<Media_ostan>> _ostan = new LoadableVar<IList<Media_ostan>>();
                                public virtual IList<Media_ostan> _____ostan { get; set; }
                                public virtual IList<Media_ostan> ostan
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Media_ostan, Guid>(ref _ostan, x => x._____ostan,
                                            ModelRepositories.jah.Media_ostan_Repository.ListByMediaPK<Media>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Media = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.ostan, x => x._____ostan, _ostan, value); }
                                }

                                    

                                LoadableVar<IList<Section>> _bakhshha = new LoadableVar<IList<Section>>();
                                public virtual IList<Section> _____bakhshha { get; set; }
                                public virtual IList<Section> bakhshha
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Section, Guid>(ref _bakhshha, x => x._____bakhshha,
                                            ModelRepositories.jah.Section_Repository.ListByMediaPK<Media>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Media = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.bakhshha, x => x._____bakhshha, _bakhshha, value); }
                                }

                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            




                          if (_GPN(x => x.onvan) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____onvan), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.tv_rd) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____tv_rd), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.mozuaat) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____mozuaat), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.sathe_mokhatab) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____sathe_mokhatab), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ostan) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ostan), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.bakhshha) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____bakhshha), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
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
                    
            if (Dic.ContainsKey(_GPN(x => x.tv_rd.id).ToClientDsFieldName()))
            {
                try
                {
                    this.tv_rd= ModelRepositories.jah.TVRD_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.tv_rd.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.tv_rd), ref Dic);

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
                return ModelRepositories.jah.Media_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
public class MediaLog: LogModelBase<MediaLog>
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

public virtual int tedad_barnameh { get; set; }

public virtual string shomareh { get; set; }


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
                                    

                                            LoadableVar<TVRD> _tv_rd= new LoadableVar<TVRD>();
                                            public virtual TVRD _____tv_rd { get; set; }
                                            public virtual TVRD tv_rd
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<TVRD, Guid>
                                                        (ref _tv_rd,
                                                        x => x._____tv_rd,
                                                        ModelRepositories.jah.TVRD_Repository.ByPK,
                                                        x => x._____tv_rd.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.tv_rd, x => x._____tv_rd, _tv_rd, value);

                                                }
                                            }
                                    
}
}

