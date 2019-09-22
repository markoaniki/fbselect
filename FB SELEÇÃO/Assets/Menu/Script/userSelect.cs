using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userSelect : MonoBehaviour{
    string URL = "http://localhost/fbselect2/usersSelect.php";
    public string [] usersData;

    IEnumerator Start(){
        WWW users = new WWW (URL);
        yield return users;
        string usersDataString = users.text;
        usersData = usersDataString.Split (';');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
