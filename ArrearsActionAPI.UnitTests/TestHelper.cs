using ArrearsActionAPI.V1.Boundary;
using Bogus;
using System;
using System.Collections.Generic;
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
    }
}
