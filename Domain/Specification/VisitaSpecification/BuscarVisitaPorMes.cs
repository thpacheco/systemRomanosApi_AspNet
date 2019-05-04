using RomanosApi.Core;
using RomanosApi.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace RomanosApi.Domain.Specification.VisitaSpecification
{
    public class BuscarVisitaPorMes : SpecificationBase<Visita>
    {
        public override Expression<Func<Visita, bool>> ToExpression()
        {
            return item => item.Data == DateTime.Now.Month;
        }
    }
}
