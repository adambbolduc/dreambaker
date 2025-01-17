﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NetworkManager : MonoBehaviour {


	private const string gameTypeName = "DreamBakerGame";
	private string gameName = "TheOneGame";
	private HostData[] hostList;

    public string MASTERSERVER_IP = "192.168.0.113";
    public int MASTERSERVER_PORT = 23466;
    public int NAT_FACILITATOR_PORT = 50005;

	public void startServer(){
		Network.InitializeServer (2, 25003, !Network.HavePublicAddress());
		MasterServer.RegisterHost (gameTypeName, gameName);
		//refreshHostList ();
	}

	void OnServerInitialized(){
		Debug.Log("Server Initialized");
	}

	public void joinServer(){
        if (hostList[0] != null)
        {
            Network.Connect(hostList[0]);
        }
    }

	private void joinServer(HostData hostData){
		Network.Connect (hostData);
	}

	void OnConnectedToServer(){
		Debug.Log ("Server Joined");
	}

	public void refreshHostList(){
		MasterServer.RequestHostList (gameTypeName);
	}

	void OnMasterServerEvent(MasterServerEvent serverEvent){
		Debug.Log(serverEvent.ToString());
		if (serverEvent == MasterServerEvent.HostListReceived) {
			hostList = MasterServer.PollHostList();
		}
	}

	void Start(){
        initializeMasterServer();
        initializeFacilitator();
    }

    private void initializeMasterServer()
    {
        MasterServer.ipAddress = MASTERSERVER_IP;
        MasterServer.port = MASTERSERVER_PORT;
    }

    private void initializeFacilitator()
    {
        Network.natFacilitatorIP = MASTERSERVER_IP;
        Network.natFacilitatorPort = NAT_FACILITATOR_PORT;
    }

    internal void setMasterServerIP(string newMasterServerIP)
    {
        MASTERSERVER_IP = newMasterServerIP;
    }
}
