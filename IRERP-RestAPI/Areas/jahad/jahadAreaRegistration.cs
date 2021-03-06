
                                    using System.Web.Mvc;

                                    namespace IRERP_RestAPI.Areas.jahad
                                    {
                                        public class jahadAreaRegistration : AreaRegistration
                                        {
                                            public override string AreaName
                                            {
                                                get
                                                {
                                                    return "jahad";
                                                }
                                            }

                                            public override void RegisterArea(AreaRegistrationContext context)
                                            {
                                                context.MapRoute(
                                                    "jahad_default",
                                                    "jahad/{controller}/{action}/{id}",
                                                    new { action = "Index", id = UrlParameter.Optional }
                                                );

                                                context.MapRoute("jahad_DataSource", "jahad/{controller}/{DataSource}/{*parts}",
                                        defaults: new { controller = "jahad", action = "DataSource" },
                                        constraints: new { DataSource = "DataSource" }
                                        );


                                                context.MapRoute("jahadArea_FileFieldUpload", "jahad/{controller}/{FileFieldUpload}/{*parts}",
                                        defaults: new { controller = "jahad", action = "FileFieldUpload" },
                                        constraints: new { FileFieldUpload = "FileFieldUpload" }
                                        );
                                            }
                                        }
                                    }

                                    