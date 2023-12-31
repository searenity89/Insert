﻿using System;
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
    public class MidRateService : IMidRateService
    {
        public IRateRepository<MidRateTable> _midRateRepository;
        public IMapper _mapper;

        public MidRateService(IRateRepository<MidRateTable> midRateRepository, IMapper mapper)
        {
            _midRateRepository = midRateRepository;
            _mapper = mapper;
        }

        public async Task<MidRateTableModel> GetMidRates(Models.TableType tableType)
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

                var midRatesDto = JsonConvert.DeserializeObject<List<MidRateTableDto>>(jsonResult);
                var midRates = _mapper.Map<MidRateTableModel>(midRatesDto.FirstOrDefault());
                midRates.TableType = tableType;

                await _midRateRepository.AddRates(_mapper.Map<MidRateTable>(midRates));

                return midRates;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}