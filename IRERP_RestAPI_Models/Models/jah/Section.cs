
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
public class Section:IRERP_RestAPI.Bases.ModelBaseLog<Section, SectionLog>{
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


                                            LoadableVar<Media> _Media= new LoadableVar<Media>();
                                            public virtual Media _____Media { get; set; }
                                            public virtual Media Media
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Media, Guid>
                                                        (ref _Media,
                                                        x => x._____Media,
                                                        ModelRepositories.jah.Media_Repository.ByPK,
                                                        x => x._____Media.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Media, x => x._____Media, _Media, value);

                                                }
                                            }
                                    
public virtual string nobat { get; set; }

public virtual string Pakhsh { get; set; }

public virtual string enteshar { get; set; }


                                LoadableVar<IList<Section_karshenas>> _karshenas = new LoadableVar<IList<Section_karshenas>>();
                                public virtual IList<Section_karshenas> _____karshenas { get; set; }
                                public virtual IList<Section_karshenas> karshenas
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Section_karshenas, Guid>(ref _karshenas, x => x._____karshenas,
                                            ModelRepositories.jah.Section_karshenas_Repository.ListBySectionPK<Section>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Section = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.karshenas, x => x._____karshenas, _karshenas, value); }
                                }

                                    
public virtual string tirajh { get; set; }


                                LoadableVar<IList<Section_sardabir>> _sardabir = new LoadableVar<IList<Section_sardabir>>();
                                public virtual IList<Section_sardabir> _____sardabir { get; set; }
                                public virtual IList<Section_sardabir> sardabir
                                {
                                    get
                                    {
                                        return
                                            LoadNHRelation<Section_sardabir, Guid>(ref _sardabir, x => x._____sardabir,
                                            ModelRepositories.jah.Section_sardabir_Repository.ListBySectionPK<Section>,
                                            x => x.id,
                                            (x, y) =>
                                            {
                                                    y.Section = x;
                                                    return y.Save();
                                            },
                                            (x, y) => { return y.Remove(CommitTransaction: false); }
                                       );
             
                                    }


                                    set { SetRelationProperty(x => x.sardabir, x => x._____sardabir, _sardabir, value); }
                                }

                                    
public override Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath) {





                          if (_GPN(x => x.AddedBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____AddedBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            

                          if (_GPN(x => x.ModifyBy) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____ModifyBy), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            


                          if (_GPN(x => x.Media) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____Media), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            




                          if (_GPN(x => x.karshenas) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____karshenas), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            


                          if (_GPN(x => x.sardabir) == PropertyPath) 
                                        return new Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion>(_GPN(x => x._____sardabir), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

                            
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
                    
            if (Dic.ContainsKey(_GPN(x => x.Media.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Media= ModelRepositories.jah.Media_Repository.ByPK(Guid.Parse(Dic[_GPN(x => x.Media.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Media), ref Dic);

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
                return ModelRepositories.jah.Section_Repository.ByPK((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            return null;

            }}
public class SectionLog: LogModelBase<SectionLog>
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


                                            LoadableVar<Media> _Media= new LoadableVar<Media>();
                                            public virtual Media _____Media { get; set; }
                                            public virtual Media Media
                                            {
                                                get
                                                {
                                                    return LoadNHRelation<Media, Guid>
                                                        (ref _Media,
                                                        x => x._____Media,
                                                        ModelRepositories.jah.Media_Repository.ByPK,
                                                        x => x._____Media.id);
                                                }
                                                set
                                                {
                                                    SetRelationProperty(x => x.Media, x => x._____Media, _Media, value);

                                                }
                                            }
                                    
public virtual string nobat { get; set; }

public virtual string Pakhsh { get; set; }

public virtual string enteshar { get; set; }

public virtual string tirajh { get; set; }

}
}

