using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Insert.Dtos;
using Insert.Entities;
using Insert.Models;
using Insert.Repositories.Interfaces;
using Insert.Services.Interfaces;
using Newtonsoft.Json;

namespace Insert.Services.Implementations
{
    public class RateService : IRateService
    {
        public IRateRepository<RateTable> _rateRepository;
        public IMapper _mapper;

        public RateService(IRateRepository<RateTable> rateRepository, IMapper mapper)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
        }

        public async Task<RateTableModel> GetRates(Models.TableType tableType)
        {
            try
            {
                var WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://api.nbp.pl/api/exchangerates/tables/{0}/", tableType.ToString()));

                WebReq.Method = "GET";

                var WebResp = (HttpWebResponse)WebReq.GetResponse();

                string jsonResult;
                using (var stream = WebResp.GetResponseStream())
                {
                    var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonResult = reader.ReadToEnd();
                }

                var ratesDto = JsonConvert.DeserializeObject<List<RateTableDto>>(jsonResult);
                var rates = _mapper.Map<RateTableModel>(ratesDto.FirstOrDefault());
                rates.TableType = tableType;

                await _rateRepository.AddRates(_mapper.Map<RateTable>(rates));

                return rates;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}