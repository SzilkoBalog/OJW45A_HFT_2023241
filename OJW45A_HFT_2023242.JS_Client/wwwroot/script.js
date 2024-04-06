let armyBases = [];
let connection = null;
getdata();
setupSignalR();

let armyBaseIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:36154/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArmyBaseCreated", (user, message) => {
        getdata();
    });

    connection.on("ArmyBaseDeleted", (user, message) => {
        getdata();
    });

    connection.on("ArmyBaseUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:36154/armybase')
        .then(x => x.json())
        .then(y => {
            armyBases = y;
            console.log(armyBases);
            display();
        });
}

function display() {
    document.getElementById('resultarea1').innerHTML = "";
    armyBases.forEach(t => {
        document.getElementById('resultarea1').innerHTML += "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + t.numberOfBeds + "</td><td>" + t.dateOfBuild +
            "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>` +
            "</td></tr>";
        }
    )
}

function create() {
    let name = document.getElementById('basename').value;
    let numberofbeds = document.getElementById('numberofbeds').value;
    let dateofbuild = document.getElementById('dateofbuild').value;
    fetch('http://localhost:36154/armybase', {
        method: 'POST',
        headers: {'Content-Type': 'application/json',},
        body: JSON.stringify(
            {
                name: name,
                numberOfBeds: numberofbeds,
                dateOfBuild: dateofbuild
            }),
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });    
}

function remove(id) {
    fetch('http://localhost:36154/armybase/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('basenameupdate').value = armyBases.find(t => t['id'] == id)['name'];
    document.getElementById('numberofbedsupdate').value = armyBases.find(t => t['id'] == id)['numberOfBeds'];
    document.getElementById('dateofbuildupdate').value = armyBases.find(t => t['id'] == id)['dateOfBuild'];
    document.getElementById('updateformdiv').style.display = 'flex';
    armyBaseIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('basenameupdate').value;
    let numberofbeds = document.getElementById('numberofbedsupdate').value;
    let dateofbuild = document.getElementById('dateofbuildupdate').value;
    fetch('http://localhost:36154/armybase', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                id: armyBaseIdToUpdate,
                name: name,
                numberOfBeds: numberofbeds,
                dateOfBuild: dateofbuild
            }),
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });
}