let armyBases = [];
let soldiers = [];
let equipment = [];
let connection = null;
getdata();
setupSignalR();

let armyBaseIdToUpdate = -1;
let soldierIdToUpdate = -1;
let equipmentIdToUpdate = -1;

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

    connection.on("SoldierCreated", (user, message) => {
        getdata();
    });

    connection.on("SoldierUpdated", (user, message) => {
        getdata();
    });

    connection.on("SoldierDeleted", (user, message) => {
        getdata();
    });

    connection.on("EquipmentCreated", (user, message) => {
        getdata();
    });

    connection.on("EquipmentUpdated", (user, message) => {
        getdata();
    });

    connection.on("EquipmentDeleted", (user, message) => {
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

    await fetch('http://localhost:36154/soldier')
        .then(x => x.json())
        .then(y => {
            soldiers = y;
            console.log(soldiers);
            display();
        });

    await fetch('http://localhost:36154/equipment')
        .then(x => x.json())
        .then(y => {
            equipment = y;
            console.log(equipment);
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

    document.getElementById('resultarea2').innerHTML = "";
    soldiers.forEach(t => {
        document.getElementById('resultarea2').innerHTML += "<tr><td>" + t.id + "</td><td>" + t.name
            + "</td><td>" + t.age + "</td><td>" + t.weight + "</td><td>" + t.armyBaseId +
            "</td><td>" + `<button type="button" onclick="removeSoldier(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdateSoldier(${t.id})">Update</button>` +
            "</td></tr>";
    }
    )

    document.getElementById('resultarea3').innerHTML = "";
    equipment.forEach(t => {
        document.getElementById('resultarea3').innerHTML += "<tr><td>" + t.id + "</td><td>" + t.type + "</td><td>" + t.description
            + "</td><td>" + t.weight + "</td><td>" + t.soldierId +
            "</td><td>" + `<button type="button" onclick="removeEquipment(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdateEquipment(${t.id})">Update</button>` +
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
    document.getElementById('updateformdiv1').style.display = 'block';
    armyBaseIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv1').style.display = 'none';
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




function createSoldier() {
    let name = document.getElementById('soldiername').value;
    let age = document.getElementById('age').value;
    let soldierWeight = document.getElementById('soldierweight').value;
    let baseId = document.getElementById('baseid').value;
    fetch('http://localhost:36154/soldier', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name,
                age: age,
                weight: soldierWeight,
                armyBaseId: baseId
            }),
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });
}

function removeSoldier(id) {
    fetch('http://localhost:36154/soldier/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });
}

function showupdateSoldier(id) {
    document.getElementById('soldiernameupdate').value = soldiers.find(t => t['id'] == id)['name'];
    document.getElementById('ageupdate').value = soldiers.find(t => t['id'] == id)['age'];
    document.getElementById('soldierweightupdate').value = soldiers.find(t => t['id'] == id)['weight'];
    document.getElementById('baseidupdate').value = soldiers.find(t => t['id'] == id)['armyBaseId'];
    document.getElementById('updateformdiv2').style.display = 'block';
    soldierIdToUpdate = id;
}

function updateSoldier() {
    document.getElementById('updateformdiv2').style.display = 'none';
    let name = document.getElementById('soldiernameupdate').value;
    let age = document.getElementById('ageupdate').value;
    let soldierWeight = document.getElementById('soldierweightupdate').value;
    let baseId = document.getElementById('baseidupdate').value;
    fetch('http://localhost:36154/soldier', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                id: soldierIdToUpdate,
                name: name,
                age: age,
                weight: soldierWeight,
                armyBaseId: baseId
            }),
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });
}




function createEquipment() {
    let type = document.getElementById('type').value;
    let description = document.getElementById('description').value;
    let equipmentWeight = document.getElementById('equipmentweight').value;
    let soldierId = document.getElementById('soldierid').value;
    fetch('http://localhost:36154/equipment', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                type: type,
                description: description,
                weight: equipmentWeight,
                soldierId: soldierId,
            }),
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });
}

function removeEquipment(id) {
    fetch('http://localhost:36154/equipment/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });
}

function showupdateEquipment(id) {
    document.getElementById('typeupdate').value = equipment.find(t => t['id'] == id)['type'];
    document.getElementById('descriptionupdate').value = equipment.find(t => t['id'] == id)['description'];
    document.getElementById('equipmentweightupdate').value = equipment.find(t => t['id'] == id)['weight'];
    document.getElementById('soldieridupdate').value = equipment.find(t => t['id'] == id)['soldierId'];
    document.getElementById('updateformdiv3').style.display = 'block';
    equipmentIdToUpdate = id;
}

function updateEquipment() {
    document.getElementById('updateformdiv3').style.display = 'none';
    let type = document.getElementById('typeupdate').value;
    let description = document.getElementById('descriptionupdate').value;
    let equipmentWeight = document.getElementById('equipmentweightupdate').value;
    let soldierId = document.getElementById('soldieridupdate').value;
    fetch('http://localhost:36154/equipment', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                id: equipmentIdToUpdate,
                type: type,
                description: description,
                weight: equipmentWeight,
                soldierId: soldierId
            }),
    })
        .then(response => response)
        .then(data => { console.log('Success:', data); getdata(); })
        .catch((error) => { console.error('Error:', error); });
}