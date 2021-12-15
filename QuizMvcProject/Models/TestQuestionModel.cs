﻿using DotNetExtra.DataBaseParsing;
using DotNetExtra.QuizImplementation;
using QuizTemplateMvcDotnet6.VideosTools;
using System.Collections.Generic;

namespace QuizTemplateMvcDotnet6.Models
{
    public class TestQuestionModel
    {
        public string testTitle = " its test str ";

        private List<VideoItem> urlLinksVideos = new List<VideoItem>()
        {
            new VideoItem("https://cdn4.telesco.pe/file/gGenKBygk__VAM4zcwXHcXlce1_mnTTTq0q12HV6MvBnJ7jmKHk34pZCLG_dGaWo-XGsXon1iXvZO_seeTTwWK8rqxhF7kazn_e9VpbMuLKnO9r9BqxZAaX1ODq599y8NTtmrE0hiI_OBiwp-h6zkEdyep5mGK8ZL1otGX3GStpjRh-ogXWeQcSzMIsXmIuZ8fQRDTK1WuHk6XAtY5gb9NIWHQoy2zJZqulEB8iW-iScfI4rjhuQD8Fl7zInC7qEEOkYbhlv3LVNHvCoS7Fm59SkzCxa2XwhSKvY6mVB_Tn0fz7AGNF8PJAWPqimHFCPF06ZtJ-IDG-bwIZsLLwXSg", "https://cdn4.telesco.pe/file/9e591dfe45.mp4?token=iuXxtUZHJy65CWU-KZCX6Q5m_l3MOV1aqNdci8BqOKa-89HDDy5W6PC2ccR1zEkuYtztcDHL6recOV7282ghCzT3V0Rn6GFD9kLJ38FYSjLNtr3gpHsRJaKru51wyB8eoBfGQAXWRO5sORBr60xTdyYuMmpThOYoUFlGIgFWikwe9fpg73YjIPqArQRq_nx5J-MqFftypYFujjfuGLoyndBXl7O7A6gZrxJZDbAoGskCO1t8SYwXBcnhXnVM01HJDJW681skwJRbnazJXSwpQPfZIrf53cn8RLngU1BDRRK4FF5GDzbHDNEqT1_lZuSg9rMJz_07hkZs_fkAXZoxYQ"),
            new VideoItem("https://cdn4.telesco.pe/file/S0IHstwBE5YcykVkkoHBz5PzVgkFLpd4wUGfZ96OvO45E0523yKAICiUwSo7WjxDNuOJMb7Bk8c90V9P6GfIlAYMR6OAKQPN30N_MBkB3hfkyAPl1VijBna76S-9jyt6GddIUA4p4gwgyya34opOrHYykhdvv5o23tRWIaHVISnASw2_v0t2eo3Ppvgakz2STCOmfBEntsRyKMRBkXCYTEhflXuoFfiY3nHGWCHbdUTMjwwhgGCx1xkRX_eysnbodFkbqq7pUWwEfOCNmGV99W8zXEe-zmHkQgDrfhJ-w26-xOv_bkQqP_oobIyPIki2MvyrX6iUS-a_68Q4APRQMQ", "https://cdn4.telesco.pe/file/316e017d22.mp4?token=KFmhoFLti307tLhzUHNE10KzNGfqM5dTfvF_I5dqL4TjSHkY4OVRXvgR7yvjew7l2zdxpKBBxxzsvZgmzFhBd1J4Gsh1POwRDXJsi4wzMVJ-dMUfsyBEqrrNT4KWsXneeis6QFmP-c_oWU7L2Wt1voHilRbID9IBDSHQimFjlpmaHJHsbIDWj1m0z24FcLXH-D-fNoUbCRyggZcGqUIPuuISVvuAGYbgMC2iWAFJOZecfJyuCtFVegqgrIX2KhfyxGeavhFPaDL4yZQUkqug2kc_yzd3vKon493ITfsNyWW04i76ZJ6jaRr2MJSeJrgqBZx55fxuJoGq6mryvp1t-Q")
        };

        public QuizPdd_Question currentQuestion { get; private set; }

        public void FillRandom()
        {
            currentQuestion = HolderDataNewPdd.GetRandomQuestion();
        }

        public string GetText()
        {
            //FillRandom();
            string textQuestion = QuizQuestionLoggerHelper.LogQuestionString(currentQuestion);;
            return textQuestion;
        }

        public string GetUrlRef()
        {
            return currentQuestion.GetPictureGetter().GetPictureSourceString();
        }

        public List<VideoItem> GetVideosList()
        {
            return urlLinksVideos;
        }
    }
}
