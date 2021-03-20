using MyJijoWalletData.Data;
using MyJijoWalletData.POCO;
using Newtonsoft.Json;
using System;

namespace MyJijoWalletData.DataAccess
{
    public static class LogAccess
    {
        static MyJijoWalletContext db = new MyJijoWalletContext();

        public static Log LogTransaction(object request, Response response,string origin, Exception exception = null)
        {
            Log log = new Log();
            log.Date = DateTime.Now;
            log.Origin = origin;
            log.Id = response.IdReference = Guid.NewGuid();
            log.JsonRequest = JsonConvert.SerializeObject(request, Formatting.Indented);
            log.JsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            log.Error = response.ErrorCode != ErrorCode.NoError;
            
            if (exception != null)
                log.JsonError = JsonConvert.SerializeObject(exception, Formatting.Indented);

            db.Logs.Add(log);
            db.SaveChanges();
            return log;
        }
    }

}
