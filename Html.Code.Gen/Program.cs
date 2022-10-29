using Html.Code.Gen.Lib;

Console.WriteLine("Generating html templates...");

var gen = new HtmlGen();
var data = new List<TutorialStep>();
data.Add(new TutorialStep(1, "Create resource group"
    , new CodeText("az group create --name {0} --location {1}"
    , new CodeParam[] {
        new CodeParam("CommonResourceGroup", "Choose your ResourceGroup name", "mark-resource-group")
        , new CodeParam("swedencentral", "Choose your Location name", "mark-location")
    })));
data.Add(new TutorialStep(2, "Create azure container registry"
    , new CodeText("az acr create --resource-group {0} --name {1} --sku Basic"
    , new CodeParam[] {
        new CodeParam("CommonResourceGroup", "Choose your ResourceGroup name", "mark-resource-group")
        , new CodeParam("atari-monk-acr", "Choose your Azure Container Register name", "mark-acr")
    })));
data.Add(new TutorialStep(3, "Login to your azure container registry"
    , new CodeText("az acr login --name {0}"
    , new CodeParam[] {
        new CodeParam("atari-monk-acr", "Choose your Azure Container Register name", "mark-acr")
    })));
data.Add(new TutorialStep(4, "Get code of example app"
    , new CodeText("git clone https://github.com/Azure-Samples/azure-voting-app-redis.git"
    , new CodeParam[] {})));


// data.Add(new TutorialStep {
//     Nr = 4,
//     Title = "Get code of example app",
//     //add more lines ?
//     Code = "git clone https://github.com/Azure-Samples/azure-voting-app-redis.git"
// });


// data.Add(new TutorialStep {
//     Nr = 5,
//     Title = "Modiffy docker compose file",
//     Code = "front-ports to: \"80:80\", image to: atarimonkacr.azurecr.io/azure-vote-front:v1"
// });
// data.Add(new TutorialStep {
//     Nr = 6,
//     Title = "Run locally",
//     Code = "docker-compose up --build -d"
// });
// data.Add(new TutorialStep {
//     Nr = 7,
//     Title = "Test url in browser",
//     Code = "http://localhost:80"
// });
// data.Add(new TutorialStep {
//     Nr = 8,
//     Title = "Run down locall instances",
//     Code = "docker-compose down"
// });
// data.Add(new TutorialStep {
//     Nr = 9,
//     Title = "Push image to container registry",
//     Code = "docker-compose push"
// });
// data.Add(new TutorialStep {
//     Nr = 10,
//     Title = "Verify if image is in repository",
//     Code = "az acr repository show --name atarimonkacr --repository azure-vote-front"
// });
// data.Add(new TutorialStep {
//     Nr = 11,
//     Title = "Login to Azure to use docker commands",
//     Code = "docker login azure"
// });
// data.Add(new TutorialStep {
//     Nr = 12,
//     Title = "Add your acr context",
//     Code = "docker context create aci atarimonkacicontext"
// });
// data.Add(new TutorialStep {
//     Nr = 13,
//     Title = "Verify you added",
//     Code = "docker context ls"
// });
// data.Add(new TutorialStep {
//     Nr = 14,
//     Title = "Set context",
//     Code = "docker context use atarimonkacicontext"
// });
// data.Add(new TutorialStep {
//     Nr = 15,
//     Title = "Start app in azure container instances",
//     Code = "docker compose up"
// });
// data.Add(new TutorialStep {
//     Nr = 16,
//     Title = "Get app ip",
//     Code = "docker ps"
// });
// data.Add(new TutorialStep {
//     Nr = 17,
//     Title = "Test ip in browser",
//     Code = ""
// });
// data.Add(new TutorialStep {
//     Nr = 18,
//     Title = "To see logs",
//     Code = ""
// });
// data.Add(new TutorialStep {
//     Nr = 19,
//     Title = "To stop and delete containers",
//     Code = "docker compose down"
// });
var text = gen.GetHtml(data);
File.WriteAllText(@"C:\atari-monk\Doc\test.html", text);