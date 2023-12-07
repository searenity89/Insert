using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using AutoMapper;
using Insert.Dtos;
using Insert.Models;
using Insert.Services.Interfaces;
using Newtonsoft.Json;

namespace Insert.Services.Implementations
{
    public class MidRateService : IMidRateService
    {
        public IMapper _mapper;

        public MidRateService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public MidRateTableModel GetMidRates(TableType tableType)
        {
            try
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://api.nbp.pl/api/exchangerates/tables/{0}/", tableType.ToString()));

                WebReq.Method = "GET";

                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                string jsonResult;
                using (Stream stream = WebResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonResult = reader.ReadToEnd();
                }

                var midRates = JsonConvert.DeserializeObject<List<MidRateTableDto>>(jsonResult);

                return _mapper.Map<MidRateTableModel>(midRates.FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}