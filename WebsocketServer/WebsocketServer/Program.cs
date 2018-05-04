using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebsocketServer
{
    public class Laputa : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("Client says: " + e.Data);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            base.OnClose(e);
            Console.WriteLine("Client disconnesso");
        }

        protected override void OnError(ErrorEventArgs e)
        {
            base.OnError(e);
            Console.WriteLine("Error: " + e.Message);
        }
    }

    class Program
    {
        static WebSocket ws;
        static WebSocketServer wssv;
        static int contatore = 0;

        static void Main(string[] args)
        {
            ws = new WebSocket("ws://localhost:6437/v6.json");
            wssv = new WebSocketServer(System.Net.IPAddress.Any, 6438);
            //wssv = new WebSocketServer("ws://localhost:6438");

            wssv.AddWebSocketService<Laputa>("/");
            
            ws.OnOpen += OnOpenHandler;
            ws.OnMessage += OnMessageHandler;
            ws.OnClose += OnCloseHandler;
            ws.Log.Level = LogLevel.Debug;
            wssv.Start();

            ws.Connect();
            
            ws.Send("{\"optimizeHMD\": true}");

            //Server
            Console.WriteLine("Avviato server.");
            Console.ReadKey(true);
        }

        private static void OnOpenHandler(object sender, System.EventArgs e)
        {
            Console.WriteLine("Connessi al servizio Leap Motion");
        }

        public static string twoHands = "{\"currentFrameRate\":81.321,\"devices\":[],\"gestures\":[],\"hands\":[{\"armBasis\":[[0.895276,-0.18614,-0.404763],[0.409976,0.699787,0.584994],[0.174358,-0.689674,0.702815]],\"armWidth\":61.9967,\"confidence\":1,\"direction\":[-0.0982226,0.110979,-0.988957],\"elbow\":[166.485,-54.3896,226.912],\"grabAngle\":1.41167,\"grabStrength\":0,\"id\":1,\"palmNormal\":[-0.42432,-0.903572,-0.059254],\"palmPosition\":[104.829,138.296,-24.4686],\"palmVelocity\":[-509.951,64.8311,-144.562],\"palmWidth\":87.4011,\"pinchDistance\":30.6373,\"pinchStrength\":0.331489,\"r\":[[0.97873,0.0953139,0.181669],[-0.170531,-0.114313,0.978699],[0.114051,-0.988862,-0.0956276]],\"s\":2.2302,\"sphereCenter\":[81.6273,78.1111,-48.0485],\"sphereRadius\":67.3874,\"stabilizedPalmPosition\":[106.469,137.93,-24.0226],\"t\":[16.2281,-0.968055,-155.307],\"timeVisible\":0.725599,\"type\":\"right\",\"wrist\":[121.265,124.477,44.6376]},{\"armBasis\":[[-0.679945,-0.37518,-0.630012],[-0.658049,0.691259,0.298551],[-0.323491,-0.617577,0.716905]],\"armWidth\":61.9967,\"confidence\":1,\"direction\":[0.297698,-0.0919656,-0.95022],\"elbow\":[-198.993,-44.7167,220.825],\"grabAngle\":2.3336,\"grabStrength\":0.92078,\"id\":2,\"palmNormal\":[0.591155,-0.763798,0.259129],\"palmPosition\":[-84.7648,118.068,-30.6949],\"palmVelocity\":[-27.7022,290.037,99.5253],\"palmWidth\":87.4011,\"pinchDistance\":12.8959,\"pinchStrength\":1,\"r\":[[0.538447,-0.766223,-0.35068],[0.315983,0.569387,-0.758916],[0.781172,0.297827,0.548698]],\"s\":1.06914,\"sphereCenter\":[-58.6465,75.943,-34.4393],\"sphereRadius\":41.134,\"stabilizedPalmPosition\":[-84.7015,116.945,-31.0327],\"t\":[49.2255,-14.6477,-155.118],\"timeVisible\":0.713226,\"type\":\"left\",\"wrist\":[-115.096,115.451,34.8961]}],\"id\":1745,\"interactionBox\":{\"center\":[0,200,0],\"size\":[235.247,235.247,147.751]},\"pointables\":[{\"bases\":[[[0.722582,0.663317,-0.194642],[-0.496356,0.693814,0.521779],[0.48115,-0.280417,0.830579]],[[0.671653,0.687721,-0.275539],[-0.502579,0.696199,0.512563],[0.54433,-0.205785,0.813239]],[[0.671653,0.687721,-0.275539],[-0.5811,0.719728,0.379888],[0.45957,-0.0950373,0.883042]],[[0.671653,0.687721,-0.275539],[-0.663687,0.723805,0.188749],[0.329243,0.0560975,0.942577]]],\"btipPosition\":[41.2776,146.548,-56.035],\"carpPosition\":[89.5466,134.853,32.4354],\"dipPosition\":[48.5857,147.793,-35.1131],\"direction\":[-0.45957,0.0950373,-0.883042],\"extended\":true,\"handId\":1,\"id\":10,\"length\":49.4283,\"mcpPosition\":[89.5466,134.853,32.4354],\"pipPosition\":[63.4468,144.72,-6.5581],\"stabilizedTipPosition\":[46.1032,144.34,-52.4376],\"timeVisible\":0.725599,\"tipPosition\":[46.4541,135.773,-50.6663],\"tipVelocity\":[-993.59,911.701,392.798],\"tool\":false,\"touchDistance\":0.456214,\"touchZone\":\"hovering\",\"type\":0,\"width\":19.8126},{\"bases\":[[[0.870899,-0.389306,-0.299961],[0.382841,0.920111,-0.0826379],[0.308169,-0.0428683,0.950365]],[[0.842135,-0.384369,-0.378245],[0.033902,0.737754,-0.674217],[0.5382,0.554959,0.63432]],[[0.842135,-0.384369,-0.378245],[-0.409422,0.000785247,-0.912345],[0.350974,0.923179,-0.156708]],[[0.842135,-0.384369,-0.378245],[-0.529257,-0.454588,-0.716405],[0.103418,0.803499,-0.586254]]],\"btipPosition\":[50.0517,95.9922,-57.5829],\"carpPosition\":[103.48,149.758,22.3314],\"dipPosition\":[51.7275,109.012,-67.0828],\"direction\":[-0.350974,-0.923179,0.156708],\"extended\":false,\"handId\":1,\"id\":11,\"length\":55.7744,\"mcpPosition\":[81.7029,152.788,-44.8288],\"pipPosition\":[59.7731,130.175,-70.6751],\"stabilizedTipPosition\":[58.4226,104.743,-51.4099],\"timeVisible\":0.725599,\"tipPosition\":[54.9476,100.763,-51.1859],\"tipVelocity\":[-984.234,-728.804,-1327.23],\"tool\":false,\"touchDistance\":0.333333,\"touchZone\":\"none\",\"type\":1,\"width\":18.925},{\"bases\":[[[0.826415,-0.542632,-0.150293],[0.531239,0.839883,-0.111275],[0.18661,0.0121179,0.982359]],[[0.801549,-0.540787,-0.255086],[0.323948,0.751342,-0.574929],[0.502571,0.378199,0.777424]],[[0.801549,-0.540787,-0.255086],[-0.216989,0.134448,-0.966871],[0.557168,0.830345,-0.00957793]],[[0.801549,-0.540787,-0.255086],[-0.216989,0.134448,-0.966871],[0.557168,0.830345,-0.00957793]]],\"btipPosition\":[53.6844,91.4377,-82.7954],\"carpPosition\":[114.122,146.732,18.1489],\"dipPosition\":[63.6146,106.237,-82.9661],\"direction\":[-0.557168,-0.830345,0.00957793],\"extended\":false,\"handId\":1,\"id\":12,\"length\":63.5504,\"mcpPosition\":[101.616,145.92,-47.685],\"pipPosition\":[78.6413,128.631,-83.2244],\"stabilizedTipPosition\":[71.1359,100.887,-49.7622],\"timeVisible\":0.725599,\"tipPosition\":[59.0795,93.6322,-70.8369],\"tipVelocity\":[-630.252,-343.473,-1472.05],\"tool\":false,\"touchDistance\":0.333333,\"touchZone\":\"none\",\"type\":2,\"width\":18.5869},{\"bases\":[[[0.802455,-0.596694,0.00472608],[0.594603,0.798926,-0.0903563],[0.0501393,0.075317,0.995898]],[[0.801347,-0.598028,-0.0143562],[0.573741,0.775152,-0.264501],[0.169307,0.20372,0.964279]],[[0.801347,-0.598028,-0.0143562],[0.522085,0.710898,-0.471223],[0.29201,0.370118,0.881897]],[[0.801347,-0.598028,-0.0143562],[0.258122,0.367329,-0.893556],[0.539645,0.712343,0.448722]]],\"btipPosition\":[96.7124,105.566,-116.392],\"carpPosition\":[124.138,141.077,15.5137],\"dipPosition\":[106.275,118.188,-108.44],\"direction\":[-0.29201,-0.370118,-0.881897],\"extended\":true,\"handId\":1,\"id\":13,\"length\":61.1054,\"mcpPosition\":[121.122,136.545,-44.4088],\"pipPosition\":[113.947,127.913,-85.2702],\"stabilizedTipPosition\":[89.0903,95.32,-49.4495],\"timeVisible\":0.725599,\"tipPosition\":[94.3497,103.446,-103.965],\"tipVelocity\":[33.6169,328.737,-1038.26],\"tool\":false,\"touchDistance\":0.333333,\"touchZone\":\"hovering\",\"type\":3,\"width\":17.6866},{\"bases\":[[[0.693514,-0.707715,0.134823],[0.714253,0.699887,-0.000178575],[-0.0942344,0.0964215,0.99087]],[[0.696443,-0.710713,0.0992613],[0.716863,0.682711,-0.141472],[0.0327796,0.169684,0.984953]],[[0.696443,-0.710713,0.0992613],[0.632349,0.542403,-0.553112],[0.339265,0.447979,0.827172]],[[0.696443,-0.710713,0.0992613],[0.444742,0.31892,-0.836955],[0.563179,0.627038,0.538194]]],\"btipPosition\":[120.237,99.9954,-96.6027],\"carpPosition\":[131.588,129.617,15.76],\"dipPosition\":[129.444,110.246,-87.8044],\"direction\":[-0.339265,-0.447979,-0.827172],\"extended\":true,\"handId\":1,\"id\":14,\"length\":47.9055,\"mcpPosition\":[136.837,124.247,-39.4295],\"pipPosition\":[135.737,118.556,-72.4604],\"stabilizedTipPosition\":[124.972,97.0126,-76.9294],\"timeVisible\":0.725599,\"tipPosition\":[127.829,102.886,-92.1876],\"tipVelocity\":[-1610.38,221.275,-47.4257],\"tool\":false,\"touchDistance\":0.333333,\"touchZone\":\"hovering\",\"type\":4,\"width\":15.7106},{\"bases\":[[[-0.772295,0.408137,-0.486811],[0.222725,0.891631,0.394193],[-0.594941,-0.196008,0.779504]],[[-0.52287,0.450527,-0.723625],[0.323242,0.890305,0.320737],[-0.788747,0.0662024,0.611143]],[[-0.52287,0.450527,-0.723625],[0.60594,0.793522,0.056211],[-0.599536,0.409082,0.687901]],[[-0.52287,0.450527,-0.723625],[0.844971,0.385866,-0.370311],[-0.112387,0.805067,0.582441]]],\"btipPosition\":[-22.7661,96.9305,-37.6762],\"carpPosition\":[-82.4671,131.203,26.8],\"dipPosition\":[-25.2607,114.8,-24.748],\"direction\":[0.599536,-0.409082,-0.687901],\"extended\":false,\"handId\":2,\"id\":20,\"length\":49.4283,\"mcpPosition\":[-82.4671,131.203,26.8],\"pipPosition\":[-44.648,128.029,-2.50334],\"stabilizedTipPosition\":[-20.3544,95.0996,-25.6981],\"timeVisible\":0.713226,\"tipPosition\":[-23.1997,103.448,-39.5187],\"tipVelocity\":[143.649,388.701,231.87],\"tool\":false,\"touchDistance\":-0.253958,\"touchZone\":\"touching\",\"type\":0,\"width\":19.8126},{\"bases\":[[[-0.688981,-0.645241,-0.330103],[-0.522411,0.757811,-0.390907],[-0.502386,0.0968785,0.859199]],[[-0.727472,-0.635254,-0.259302],[0.0496624,0.328174,-0.943311],[-0.684338,0.69911,0.20719]],[[-0.727472,-0.635254,-0.259302],[0.634662,-0.479378,-0.606136],[-0.260746,0.605516,-0.751906]],[[-0.727472,-0.635254,-0.259302],[0.686133,-0.672215,-0.278115],[-0.00236698,0.380236,-0.924886]]],\"btipPosition\":[-26.9154,84.2793,-26.11],\"carpPosition\":[-96.3179,139.654,10.8263],\"dipPosition\":[-26.9538,90.4408,-41.0972],\"direction\":[0.260746,-0.605516,0.751906],\"extended\":false,\"handId\":2,\"id\":21,\"length\":55.7744,\"mcpPosition\":[-60.8154,132.808,-49.8914],\"pipPosition\":[-32.9311,104.321,-58.3337],\"stabilizedTipPosition\":[-26.2926,82.8226,-31.7112],\"timeVisible\":0.713226,\"tipPosition\":[-21.9108,86.3712,-40.5644],\"tipVelocity\":[10.7644,285.461,180.864],\"tool\":false,\"touchDistance\":0.333333,\"touchZone\":\"none\",\"type\":1,\"width\":18.925},{\"bases\":[[[-0.6513,-0.745891,-0.139478],[-0.642274,0.639759,-0.422129],[-0.404095,0.18535,0.895741]],[[-0.646011,-0.74823,-0.151069],[-0.112615,0.289165,-0.950632],[-0.754975,0.597106,0.271065]],[[-0.646011,-0.74823,-0.151069],[0.637476,-0.419969,-0.645949],[-0.419874,0.513593,-0.748283]],[[-0.646011,-0.74823,-0.151069],[0.751346,-0.588365,-0.298841],[-0.134718,0.306559,-0.94227]]],\"btipPosition\":[-29.6301,74.2558,-29.6073],\"carpPosition\":[-104.949,133.289,5.8386],\"dipPosition\":[-32.0312,79.7195,-46.4011],\"direction\":[0.419874,-0.513593,0.748283],\"extended\":false,\"handId\":2,\"id\":22,\"length\":63.5504,\"mcpPosition\":[-77.8682,120.867,-54.1905],\"pipPosition\":[-43.3551,93.571,-66.5821],\"stabilizedTipPosition\":[-29.4589,71.9185,-40.8831],\"timeVisible\":0.713226,\"tipPosition\":[-28.8762,76.7898,-46.3604],\"tipVelocity\":[79.7502,229.677,267.869],\"tool\":false,\"touchDistance\":0.333333,\"touchZone\":\"none\",\"type\":2,\"width\":18.5869},{\"bases\":[[[-0.653384,-0.756577,0.0260795],[-0.699719,0.590416,-0.402246],[-0.288932,0.28107,0.91516]],[[-0.633508,-0.773046,-0.0326695],[-0.141874,0.157565,-0.977264],[-0.760618,0.614469,0.209494]],[[-0.633508,-0.773046,-0.0326695],[0.573741,-0.441011,-0.690166],[-0.519123,0.45597,-0.722913]],[[-0.633508,-0.773046,-0.0326695],[0.745296,-0.598335,-0.294157],[-0.20785,0.210699,-0.955198]]],\"btipPosition\":[-45.8957,66.2739,-24.8924],\"carpPosition\":[-112.834,124.937,3.12981],\"dipPosition\":[-49.5789,70.0075,-41.8188],\"direction\":[0.519123,-0.45597,0.722913],\"extended\":false,\"handId\":2,\"id\":23,\"length\":61.1054,\"mcpPosition\":[-95.4492,108.026,-51.9347],\"pipPosition\":[-63.2179,81.9873,-60.812],\"stabilizedTipPosition\":[-43.9823,63.4714,-44.7302],\"timeVisible\":0.713226,\"tipPosition\":[-46.4257,66.8921,-34.2285],\"tipVelocity\":[168.062,144.756,-251.877],\"tool\":false,\"touchDistance\":0.333333,\"touchZone\":\"none\",\"type\":3,\"width\":17.6866},{\"bases\":[[[-0.557778,-0.806045,0.197926],[-0.815585,0.48805,-0.31085],[-0.153961,0.334811,0.929622]],[[-0.541729,-0.832816,0.113786],[-0.499888,0.210378,-0.84015],[-0.675753,0.512014,0.530283]],[[-0.541729,-0.832816,0.113786],[0.260864,-0.295263,-0.919114],[-0.799049,0.468228,-0.377204]],[[-0.541729,-0.832816,0.113786],[0.574944,-0.465885,-0.6726],[-0.613163,0.298946,-0.731206]]],\"btipPosition\":[-61.7322,62.9761,-45.4602],\"carpPosition\":[-117.815,112.368,5.15057],\"dipPosition\":[-71.7561,67.8632,-57.4137],\"direction\":[0.799049,-0.468228,0.377204],\"extended\":false,\"handId\":2,\"id\":24,\"length\":47.9055,\"mcpPosition\":[-109.24,93.7195,-46.6276],\"pipPosition\":[-86.5784,76.5488,-64.4109],\"stabilizedTipPosition\":[-65.6574,59.6944,-59.7193],\"timeVisible\":0.713226,\"tipPosition\":[-65.3423,61.4284,-57.4189],\"tipVelocity\":[-75.4246,337.134,3.96589],\"tool\":false,\"touchDistance\":0.333333,\"touchZone\":\"none\",\"type\":4,\"width\":15.7106}],\"r\":[[0.87697,0.344894,-0.334621],[-0.430192,0.873771,-0.226848],[0.214144,0.34289,0.914641]],\"s\":1.34702,\"t\":[40.8777,-68.4573,-142.79],\"timestamp\":2471230212}";
        public static string oneHand = "{\"currentFrameRate\":110.346,\"devices\":[],\"gestures\":[],\"hands\":[{\"armBasis\":[[-0.975227,0.0448044,0.216621],[0.16405,0.803409,0.572382],[0.14839,-0.59374,0.790856]],\"armWidth\":56.3375,\"confidence\":1,\"direction\":[-0.0338727,0.190461,-0.98111],\"elbow\":[70.3224,39.8737,331.489],\"grabAngle\":0.876737,\"grabStrength\":0.0370796,\"id\":17,\"palmNormal\":[-0.16482,-0.969297,-0.182477],\"palmPosition\":[35.3309,203.847,60.4823],\"palmVelocity\":[2.93764,-6.1325,-12.4489],\"palmWidth\":85.782,\"pinchDistance\":83.8156,\"pinchStrength\":0,\"r\":[[-0.879428,0.217779,-0.423295],[-0.105588,-0.956305,-0.272638],[-0.464174,-0.19507,0.863996]],\"s\":1.21694,\"sphereCenter\":[34.8469,113.027,22.753],\"sphereRadius\":103.207,\"stabilizedPalmPosition\":[32.6451,196.301,52.4816],\"t\":[-192.695,56.7613,-3.17431],\"timeVisible\":3.43452,\"type\":\"left\",\"wrist\":[32.5495,191.011,130.176]}],\"id\":1057862,\"interactionBox\":{\"center\":[0,200,0],\"size\":[235.247,235.247,147.751]},\"pointables\":[{\"bases\":[[[-0.25585,0.966713,-0.00239028],[0.880248,0.233987,0.412811],[-0.39963,-0.103514,0.910813]],[[-0.102148,0.94301,-0.316697],[0.676556,0.299252,0.672845],[-0.729272,0.145534,0.668567]],[[-0.102148,0.94301,-0.316697],[0.688732,0.29676,0.661499],[-0.717784,0.150549,0.679795]],[[-0.102148,0.94301,-0.316697],[0.633717,0.307089,0.709999],[-0.766791,0.128171,0.62897]]],\"btipPosition\":[127.999,170.396,45.7033],\"carpPosition\":[55.5673,184.552,111.217],\"dipPosition\":[111.876,173.091,58.9286],\"direction\":[0.717784,-0.150549,-0.679795],\"extended\":true,\"handId\":17,\"id\":170,\"length\":46.8241,\"mcpPosition\":[55.5673,184.552,111.217],\"pipPosition\":[89.8879,177.703,79.753],\"stabilizedTipPosition\":[125.179,171.944,50.2448],\"timeVisible\":3.43452,\"tipPosition\":[126.676,172.515,50.7612],\"tipVelocity\":[5.77889,-6.62056,-8.04267],\"tool\":false,\"touchDistance\":0.220676,\"touchZone\":\"hovering\",\"type\":0,\"width\":17.3825},{\"bases\":[[[-0.977435,0.185296,-0.101418],[0.182594,0.982551,0.0353864],[-0.106205,-0.0160696,0.994214]],[[-0.97325,0.185736,-0.135229],[0.195572,0.978638,-0.0633898],[-0.120567,0.0881413,0.988784]],[[-0.97325,0.185736,-0.135229],[0.228656,0.840429,-0.49132],[-0.022395,0.509098,0.860417]],[[-0.97325,0.185736,-0.135229],[0.220007,0.583857,-0.781478],[0.0661941,0.790325,0.609102]]],\"btipPosition\":[62.259,180.05,-29.9892],\"carpPosition\":[50.7687,205.525,105.17],\"dipPosition\":[63.2751,192.182,-20.6391],\"direction\":[0.022395,-0.509098,-0.860417],\"extended\":true,\"handId\":17,\"id\":171,\"length\":52.8357,\"mcpPosition\":[58.1349,206.639,36.2124],\"pipPosition\":[62.7887,203.237,-1.95432],\"stabilizedTipPosition\":[62.6965,182.159,-29.4097],\"timeVisible\":3.43452,\"tipPosition\":[62.8288,184.278,-28.6011],\"tipVelocity\":[3.49974,-16.6805,-11.2715],\"tool\":false,\"touchDistance\":0.223855,\"touchZone\":\"hovering\",\"type\":1,\"width\":16.6038},{\"bases\":[[[-0.999508,0.0111873,0.0293002],[0.0123426,0.999141,0.0395503],[0.0288326,-0.0398925,0.998788]],[[-0.999835,0.0118056,0.0137837],[0.0113388,0.999376,-0.0334643],[0.0141702,0.0333025,0.999345]],[[-0.999835,0.0118056,0.0137837],[0.00453582,0.897953,-0.440068],[0.0175724,0.439933,0.897858]],[[-0.999835,0.0118056,0.0137837],[-0.00220459,0.674871,-0.737933],[0.018014,0.737842,0.674734]]],\"btipPosition\":[36.6325,186.723,-39.7936],\"carpPosition\":[39.8957,209.239,103.51],\"dipPosition\":[36.9367,199.181,-28.4016],\"direction\":[-0.0175724,-0.439933,-0.897858],\"extended\":true,\"handId\":17,\"id\":172,\"length\":60.2021,\"mcpPosition\":[37.9993,211.862,37.8149],\"pipPosition\":[37.3856,210.42,-5.46247],\"stabilizedTipPosition\":[36.9096,189.166,-36.597],\"timeVisible\":3.43452,\"tipPosition\":[35.6193,187.583,-36.2513],\"tipVelocity\":[4.50722,-14.4399,-14.2623],\"tool\":false,\"touchDistance\":0.212064,\"touchZone\":\"hovering\",\"type\":2,\"width\":16.3071},{\"bases\":[[[-0.982438,-0.0701567,0.172895],[-0.0581864,0.995607,0.0733616],[0.177283,-0.0620131,0.982204]],[[-0.975938,-0.0721977,0.205751],[-0.0608192,0.996276,0.0611086],[0.209396,-0.0471246,0.976695]],[[-0.975938,-0.0721977,0.205751],[-0.146632,0.915679,-0.374207],[0.161385,0.395373,0.904232]],[[-0.975938,-0.0721977,0.205751],[-0.201992,0.654749,-0.728357],[0.0821293,0.752391,0.653577]]],\"btipPosition\":[4.09366,193.33,-27.5787],\"carpPosition\":[28.3641,210.246,103.109],\"dipPosition\":[5.47233,205.96,-16.6073],\"direction\":[-0.161385,-0.395373,-0.904232],\"extended\":true,\"handId\":17,\"id\":173,\"length\":57.8859,\"mcpPosition\":[17.8947,213.909,45.105],\"pipPosition\":[9.48902,215.8,5.89809],\"stabilizedTipPosition\":[5.4515,199.21,-22.6889],\"timeVisible\":3.43452,\"tipPosition\":[3.62918,192.952,-24.0957],\"tipVelocity\":[3.04309,-14.0873,-13.5341],\"tool\":false,\"touchDistance\":0.235129,\"touchZone\":\"hovering\",\"type\":3,\"width\":15.5173},{\"bases\":[[[-0.932107,-0.240395,0.270899],[-0.19439,0.963158,0.185845],[0.305595,-0.120568,0.944497]],[[-0.859256,-0.258586,0.441376],[-0.1752,0.959406,0.221007],[0.480609,-0.112573,0.86968]],[[-0.859256,-0.258586,0.441376],[-0.362304,0.916752,-0.16823],[0.361131,0.304465,0.881411]],[[-0.859256,-0.258586,0.441376],[-0.470634,0.737728,-0.484006],[0.200459,0.623611,0.755596]]],\"btipPosition\":[-25.1911,199.898,-1.74425],\"carpPosition\":[16.2333,204.739,104.707],\"dipPosition\":[-22.0867,209.556,9.95724],\"direction\":[-0.361131,-0.304465,-0.881411],\"extended\":true,\"handId\":17,\"id\":174,\"length\":45.3815,\"mcpPosition\":[-0.472417,211.33,53.0744],\"pipPosition\":[-15.7407,214.906,25.446],\"stabilizedTipPosition\":[-23.4064,202.271,0.63107],\"timeVisible\":3.43452,\"tipPosition\":[-24.4106,200.319,0.957784],\"tipVelocity\":[2.60849,-12.5842,-13.1447],\"tool\":false,\"touchDistance\":0.248772,\"touchZone\":\"hovering\",\"type\":4,\"width\":13.7836}],\"r\":[[-0.879428,0.217779,-0.423295],[-0.105588,-0.956305,-0.272638],[-0.464174,-0.19507,0.863996]],\"s\":1.21694,\"t\":[-192.695,56.7613,-3.17431],\"timestamp\":12943891136}";

        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            ++contatore;
            contatore %= 5;
            if (contatore == 0)
            {

                if (wssv.IsListening)
                {

                    wssv.WebSocketServices.Broadcast(e.Data);
                    //wssv.WebSocketServices.Broadcast(twoHands);
                    //Console.WriteLine(e.Data);
                }
            }
        }

        private static void OnCloseHandler(object sender,CloseEventArgs e)
        {
                Console.WriteLine("Connessione al servizio Leap Motion fallita. Riproviamo");
                Thread.Sleep(1000); // If necessary 
                ws.Close();
                ws = new WebSocket("ws://localhost:6437/v6.json");
                ws.OnOpen += OnOpenHandler;
                ws.OnMessage += OnMessageHandler;
                ws.OnClose += OnCloseHandler;
                ws.Log.Level = LogLevel.Debug;
                ws.Connect();
                ws.Send("{\"optimizeHMD\": true}");

           // }
        }
    }
}

/*
using System; 
using Leap; 
using WebSocketSharp; 
using WebSocketSharp.Server; 
 
namespace LeapServer 
{ 
    public class Laputa : WebSocketBehavior 
    { 
        protected override void OnMessage(MessageEventArgs e) 
        { 
            Console.WriteLine("Client says: " + e.Data); 
        } 
 
        protected override void OnClose(CloseEventArgs e) 
        { 
            base.OnClose(e); 
            Console.WriteLine("Client disconnesso"); 
        } 
 
        protected override void OnError(ErrorEventArgs e) 
        { 
            base.OnError(e); 
            Console.WriteLine("Error: " + e.Message); 
        } 
    } 
 
    class Program 
    { 
        static Controller controller; 
        static Frame frame; 
        static WebSocketServer wssv;
        static SampleListener listener;
        
        static void Main(string[] args) 
        { 
            wssv = new WebSocketServer(System.Net.IPAddress.Any, 6438); 
 
            wssv.AddWebSocketService<Laputa>("/"); 
            wssv.Start(); 
            Console.WriteLine("Avviato server.");
 
            controller = new Controller();
             
            frame = new Frame();

            listener = new SampleListener();
            controller.Connect += listener.OnServiceConnect;
            controller.Device += listener.OnConnect;
            controller.FrameReady += listener.OnFrame;

            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();
            
            controller.Dispose();
        }

        class SampleListener
        {
            public void OnServiceConnect(object sender, ConnectionEventArgs args)
            {
                Console.WriteLine("Service Connected");
            }

            public void OnConnect(object sender, DeviceEventArgs args)
            {
                Console.WriteLine("Controller Connected");
            }

            public void OnFrame(object sender, FrameEventArgs args)
            {
                frame = args.frame;
                Console.WriteLine(frame);

                if (wssv.IsListening)
                {
                    wssv.WebSocketServices.Broadcast(frame.Serialize);  // has not been implemented yet and never will
                }
            }
        }
    } 
}
*/