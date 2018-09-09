using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace berg8.api.Controllers
{
    using berg8.api.Model;
    using berg8.api.Model.Enum;
    using berg8.api.Model.Request;
    using berg8.api.Model.Response;

    [EnableCors(Setting.policyOriginName)]
    [Route("[controller]/[action]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {

        #region [ Constructor ]
        public WorkflowController()
        {
        }

        #endregion

        #region [ GetDocuments ]
        //[DisableCors]
        [HttpPost]
        public IActionResult GetDocuments([FromBody] REQ_DOCUMENT request)
        {
            RES_DOCUMENT oResult = new RES_DOCUMENT();

            List<DOCUMENT> oDocuments = new List<DOCUMENT>();
            List<MESSAGER> oMessages = new List<MESSAGER>();
            try
            {

                int ilength = new Random().Next(10, 100);
                for (int i = 0; i < ilength; i++)
                {
                    if (request.FILTER.REQUEST_TYPES.Length > 0)
                    {
                        for (int ii = 0; ii < request.FILTER.REQUEST_TYPES.Length; ii++)
                        {
                            DOCUMENT oItem = request.ToDocumentMockup($"{i}", DOCUMENT_TYPE.REQUEST, request.FILTER.REQUEST_TYPES[ii]);
                            oDocuments.Add(oItem);
                        }
                    }

                    if (request.FILTER.CLAIM_TYPES.Length > 0)
                    {
                        for (int ii = 0; ii < request.FILTER.CLAIM_TYPES.Length; ii++)
                        {
                            DOCUMENT oItem = request.ToDocumentMockup($"{i}", DOCUMENT_TYPE.CLAIM, request.FILTER.CLAIM_TYPES[ii]);
                            oDocuments.Add(oItem);
                        }
                    }

                }
                oMessages.Add(new MESSAGER() { CODE = MESSAGE_TYPE.SUCCESS });
            }
            catch (Exception ex)
            {
                oMessages.Add(new MESSAGER() { CODE = MESSAGE_TYPE.ERROR, MESSAGE = ex.Message });
            }
            finally
            {
                oResult.DOCUMENTS = oDocuments;
                oResult.MESSAGES = oMessages;
            }
            return Ok(oResult);
        }

        #endregion [ GetDocuments ]
        #region [ GetCommandButton ]
        [HttpPost]
        public IActionResult GetCommandActions([FromBody] REQ_COMMAND request)
        {
            RES_COMMAND oResult = new RES_COMMAND();

            IList<ACTION> oActions = new List<ACTION>();
            IList<MESSAGER> oMessages = new List<MESSAGER>();

            try
            {

                oActions = request.ToActionMockup();
                oMessages.Add(new MESSAGER() { CODE = MESSAGE_TYPE.SUCCESS });

            }
            catch (Exception ex)
            {
                oMessages.Add(new MESSAGER() { CODE = MESSAGE_TYPE.ERROR, MESSAGE = ex.Message });
            }
            finally
            {
                oResult.ACTIONS = oActions;
                oResult.MESSAGES = oMessages;
            }
            return Ok(oResult);
        }

        #endregion
        #region [ GetTasks ]
        [HttpPost]
        public IActionResult GetTasks([FromBody] REQ_TASK request)
        {
            RES_TASK oResult = new RES_TASK();

            IList<TASK> oTasks = new List<TASK>();
            IList<MESSAGER> oMessages = new List<MESSAGER>();

            try
            {
                oTasks = request.ToTaskMockup();
                oMessages.Add(new MESSAGER() { CODE = MESSAGE_TYPE.SUCCESS });
            }
            catch (Exception ex)
            {
                oMessages.Add(new MESSAGER() { CODE = MESSAGE_TYPE.ERROR, MESSAGE = ex.Message });
            }
            finally
            {
                oResult.TASKS = oTasks;
                oResult.MESSAGES = oMessages;
            }
            return Ok(oResult);

        }

        #endregion
    
    }
}
