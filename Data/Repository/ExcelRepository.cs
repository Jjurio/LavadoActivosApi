using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Data.Interface;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using LavadoActivosApi.Models;

namespace LavadoActivosApi.Data.Repository
{
    public class ExcelRepository : IExcelRepository
    {
        private readonly string _connectionString;
        public ExcelRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task InsertarExcel(ExcelClase excelClase)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_InsertarExcel", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@code", excelClase.code));
                    cmd.Parameters.Add(new SqlParameter("@description", excelClase.description));
                    cmd.Parameters.Add(new SqlParameter("@reportNumber", excelClase.reportNumber));
                    cmd.Parameters.Add(new SqlParameter("@rosType", excelClase.rosType));
                    cmd.Parameters.Add(new SqlParameter("@rosNumber", excelClase.rosNumber));
                    cmd.Parameters.Add(new SqlParameter("@rosYear", excelClase.rosYear));
                    cmd.Parameters.Add(new SqlParameter("@birthDate", excelClase.birthDate));
                    cmd.Parameters.Add(new SqlParameter("@detectionDate", excelClase.detectionDate));
                    cmd.Parameters.Add(new SqlParameter("@startDate", excelClase.startDate));
                    cmd.Parameters.Add(new SqlParameter("@targetEffective", excelClase.targetEffective));
                    cmd.Parameters.Add(new SqlParameter("@realEffective", excelClase.realEffective));
                    cmd.Parameters.Add(new SqlParameter("@indexEffective", excelClase.indexEffective));
                    cmd.Parameters.Add(new SqlParameter("@reportDate", excelClase.reportDate));
                    cmd.Parameters.Add(new SqlParameter("@reportSource", excelClase.reportSource));
                    cmd.Parameters.Add(new SqlParameter("@customerCond", excelClase.customerCond));
                    cmd.Parameters.Add(new SqlParameter("@customerType", excelClase.customerType));
                    cmd.Parameters.Add(new SqlParameter("@customerStatus", excelClase.customerStatus));
                    cmd.Parameters.Add(new SqlParameter("@customerDoc", excelClase.customerDoc));
                    cmd.Parameters.Add(new SqlParameter("@naturePersonLinkDate", excelClase.naturePersonLinkDate));
                    cmd.Parameters.Add(new SqlParameter("@economyAct", excelClase.economyAct));
                    cmd.Parameters.Add(new SqlParameter("@naturePersonStatus", excelClase.naturePersonStatus));
                    cmd.Parameters.Add(new SqlParameter("@legalPersonDate", excelClase.legalPersonDate));
                    cmd.Parameters.Add(new SqlParameter("@legalPersonLinkDate", excelClase.legalPersonLinkDate));
                    cmd.Parameters.Add(new SqlParameter("@legalPersonStatus", excelClase.legalPersonStatus));
                    cmd.Parameters.Add(new SqlParameter("@fSoles", excelClase.fSoles));
                    cmd.Parameters.Add(new SqlParameter("@fDollars", excelClase.fDollars));
                    cmd.Parameters.Add(new SqlParameter("@fEuros", excelClase.fEuros));
                    cmd.Parameters.Add(new SqlParameter("@fEfectivo", excelClase.fEfectivo));
                    cmd.Parameters.Add(new SqlParameter("@fCheque", excelClase.fCheque));
                    cmd.Parameters.Add(new SqlParameter("@fTransferencia", excelClase.fTransferencia));
                    cmd.Parameters.Add(new SqlParameter("@fOtros", excelClase.fOtros));
                    cmd.Parameters.Add(new SqlParameter("@counterMoney", excelClase.counterMoney));
                    cmd.Parameters.Add(new SqlParameter("@atmMoney", excelClase.atmMoney));
                    cmd.Parameters.Add(new SqlParameter("@internetMoney", excelClase.internetMoney));
                    cmd.Parameters.Add(new SqlParameter("@otherMoney", excelClase.otherMoney));
                    cmd.Parameters.Add(new SqlParameter("@localidad", excelClase.localidad));
                    cmd.Parameters.Add(new SqlParameter("@pais", excelClase.pais));
                    cmd.Parameters.Add(new SqlParameter("@cuentaCorrienteB", excelClase.cuentaCorrienteB));
                    cmd.Parameters.Add(new SqlParameter("@cuentaAhorrosB", excelClase.cuentaAhorrosB));
                    cmd.Parameters.Add(new SqlParameter("@transferenciasB", excelClase.transferenciasB));
                    cmd.Parameters.Add(new SqlParameter("@girosB", excelClase.girosB));
                    cmd.Parameters.Add(new SqlParameter("@chequeB", excelClase.chequeB));
                    cmd.Parameters.Add(new SqlParameter("@tarjetaCreditoB", excelClase.tarjetaCreditoB));
                    cmd.Parameters.Add(new SqlParameter("@creditoComercialB", excelClase.creditoComercialB));
                    cmd.Parameters.Add(new SqlParameter("@creditoConsumoB", excelClase.creditoConsumoB));
                    cmd.Parameters.Add(new SqlParameter("@compraDivisaB", excelClase.compraDivisaB));
                    cmd.Parameters.Add(new SqlParameter("@otrosB", excelClase.otrosB));
                    cmd.Parameters.Add(new SqlParameter("@regimenAudit", excelClase.regimenAudit));
                    cmd.Parameters.Add(new SqlParameter("@frecuencyAudit", excelClase.frecuencyAudit));
                    cmd.Parameters.Add(new SqlParameter("@verificationAudit", excelClase.verificationAudit));
                    cmd.Parameters.Add(new SqlParameter("@lastAudit", excelClase.lastAudit));
                    cmd.Parameters.Add(new SqlParameter("@nextAudit", excelClase.nextAudit));
                    cmd.Parameters.Add(new SqlParameter("@hoursAudit", excelClase.hoursAudit));
                    cmd.Parameters.Add(new SqlParameter("@minutesAudit", excelClase.minutesAudit));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;


                }
            }
        }
    }
}
