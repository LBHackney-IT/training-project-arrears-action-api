using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Domain;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrearsActionAPI.UnitTests
{
    public static class TestHelper
    {
        private static Faker _faker = new Faker();

        public static GetAractionsByPropRefRequest Generate_GetAractionsByPropRefRequest()
        {
            var rand_prop_ref = _faker.Random.Hash().ToString();
            return new GetAractionsByPropRefRequest() {
                PropertyRef = rand_prop_ref
            };
        }

        private static ArrearsAction Generate_ArrearsAction() //TODO: Generate with proper fields
        {
            return new ArrearsAction();
        }

        public static List<ArrearsAction> Generate_ListOfArrearsActions() //Messing about here, IRL would do a for loop.
        {
            return Enumerable.Range(0, _faker.Random.Int(1, 10))
                .Aggregate(
                    new List<ArrearsAction>(), 
                    (acc, _) => {
                        acc.Add(Generate_ArrearsAction());
                        return acc;
                    }
                );
        }
    }
}
