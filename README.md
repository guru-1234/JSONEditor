# Game Object Instatiater Using JSON Data

Game object instantiater tool is used to dynamically generate gameobject with a custom heirarchal strucutre 
and can save the structure as JSON in a desired Path user need. Also read and load the pre-exist JSON data.

# How to Use the Insatntiater Tool #

## Generate JSON Data ##
   * Create a template for your heirarchial structure with 'RootParent' class in inspector 
   * Feed the desired path in 'Path To Save JSON' field
   * Feed the file name to be in thr 'File Name To Save'
   * Click 'Generate JSON Data' button to generate a JSON file in the desired path
     ![HowToUse](https://github.com/guru-1234/JSONEditor/assets/59476943/19581298-7306-4104-b7b9-a7e913067e2a)
  * Required warning will be shown if required fields are empty
    ![warning1](https://github.com/guru-1234/JSONEditor/assets/59476943/ab0eabfd-4c85-40c1-85bb-4dc227e5fd8e)
  ### Limitations ###
  * First time storing an JSON will be slow to reflect back to the unity editor, there would be delay

## Editing an JSON as String and Storing it ##
   * Put the JSON file inside 'JSON File To Read' 
   * Click the toggle button 'Edit JSON as String'
   * That will popsup a 'JSON As text' field
   * JSON will be shown in that field with JSON indent format, can modify
   * Click the 'Save Data From JSON String' button, it will reflect the data to file itself![button1](https://github.com/guru-1234/JSONEditor/assets/59476943/578d8140-e8d9-401a-8020-57f51b56cb5e)
     ![EditAstring2](https://github.com/guru-1234/JSONEditor/assets/59476943/2c3e880d-614e-4203-92a7-5aff8adcb9d7)

  * Required warning will be shown if data is not presented
    ![warning2](https://github.com/guru-1234/JSONEditor/assets/59476943/de48bb71-2745-4f7f-8dd8-bc7a4ae4478d)


  ### Limitations ###
  * This way of storing only reflect in the JSON file, not on 'Root Parent' Class template
  * Have to Click 'Load & Read JSON Data' button to reflect on it

## Dynamically creating Gameobjects ##
   * Put the JSON file inside 'JSON File TO Read' 
   * Click the toggle button 'Edit JSON as String'
   * That will popsup a 'JSON As text' field
   * JSON will be shown in that field with JSON indent format, can modify
   * Click the 'Save Data From JSON String' button, it will reflect the data to file itself![button1](https://github.com/guru-1234/JSONEditor/assets/59476943/578d8140-e8d9-401a-8020-57f51b56cb5e)
     ![EditAstring2](https://github.com/guru-1234/JSONEditor/assets/59476943/2c3e880d-614e-4203-92a7-5aff8adcb9d7)

  * Required warning will be shown if data is not presented
    ![warning2](https://github.com/guru-1234/JSONEditor/assets/59476943/de48bb71-2745-4f7f-8dd8-bc7a4ae4478d)


  ### Limitations ###
  * This way of storing only reflect in the JSON file, not on 'Root Parent' Class template
  * Have to Click 'Load & Read JSON Data' button to reflect on it
