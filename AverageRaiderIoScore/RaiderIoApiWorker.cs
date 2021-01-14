﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.WebUtilities;

namespace AverageRaiderIoScore
{
    class RaiderIoApiWorker
    {
        private const string baseUrl = "https://raider.io/api/v1/characters/profile";

        public string LoadCharacterJson(Character character)
        {
            var url = ConstructUrl(character.Region.ToString(), character.Realm, character.Name);
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private string ConstructUrl(string region, string realm, string name)
        {
            var param = new Dictionary<string, string>() { { "region", region },
                                                            {"realm", realm },
                                                            {"name", name },
                                                            {"fields", "mythic_plus_scores_by_season:current" } };

            var newUrl = new Uri(QueryHelpers.AddQueryString(baseUrl, param));
            return newUrl.AbsoluteUri;
        }
    }
}
