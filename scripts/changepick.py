from pynput.keyboard import Key, Controller
import time

kbd = Controller()

keys = ['1', '2', '3', '4', '5', '6', '7', '8', '9']

time.sleep(30)
print("launching")

for key in keys:
    kbd.press(key)
    print(f"pressing {key}")
    kbd.release(key)
    time.sleep(120)
