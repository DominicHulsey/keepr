<template>
  <div class="makeKeep">
    <!-- Button trigger modal -->
    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Create New Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="makeKeep">
              <div class="input-group my-4">
                <div class="input-group-prepend">
                  <div class="input-group-text text-white" style="border-radius:0;background-color:#9854bb">Title</div>
                </div>
                <input type="text" class="form-control" v-model="newKeep.name" placeholder="Name">
              </div>
              <div class="input-group my-4">
                <div class="input-group-prepend">
                  <div class="input-group-text text-white" style="border-radius:0;background-color:#fc0095">Description
                  </div>
                </div>
                <input type="text" class="form-control" v-model="newKeep.description" placeholder="Description">
              </div>
              <div class="input-group my-4">
                <div class="input-group-prepend">
                  <div class="input-group-text text-white" style="border-radius:0;background-color:black">Image</div>
                </div>
                <input type="text" class="form-control" v-model="newKeep.img" placeholder="url">
              </div>
              <div class="form-check">
                <!-- <input type="checkbox" class="form-check-input" v-model="newKeep.isPrivate" id="exampleCheck1"> -->
                <label class="row justify-content-center">
                  <p class="mx-2" style="font-size:16px;font-weight:bold;">Private post? </p>
                  <input class="mt-1" v-model="newKeep.isPrivate" type="checkbox" checked="checked">
                </label>
                <!-- <label class="form-check-label p-2" for="exampleCheck1">Private</label> -->
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal"
                  style="border-radius:0;">Close</button>
                <button type="submit" class="btn btn-primary text-white"
                  style="border-radius:0;background-color:black">Create
                  Keep</button>
                <!-- @click="hideModal()" -->
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'makeKeep',
    data() {
      return {
        newKeep: {}
      }
    },
    computed: {},
    methods: {
      makeKeep() {
        let payload = {
          name: this.newKeep.name,
          description: this.newKeep.description,
          img: this.newKeep.img,
          isPrivate: this.newKeep.isPrivate || false
        }
        if (payload.isPrivate) {
          payload.isPrivate = 1
        }
        else payload.isPrivate = 0
        this.$store.dispatch("makeKeep", payload)
      },
      hideModal() {
        $('#exampleModal').modal('hide');
      }
    }, components: {}
  } 
</script>
<style scoped>
  .bgForm {
    background-color: #fc0095
  }

  /* Customize the label (the container) */
  .container {
    display: block;
    position: relative;
    padding-left: 35px;
    margin-bottom: 12px;
    cursor: pointer;
    font-size: 22px;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
  }

  /* Hide the browser's default checkbox */
  .container input {
    position: absolute;
    opacity: 0;
    cursor: pointer;
    height: 0;
    width: 0;
  }

  /* Create a custom checkbox */
  .checkmark {
    position: absolute;
    top: 0;
    left: 0;
    height: 25px;
    width: 25px;
    background-color: #eee;
  }

  /* On mouse-over, add a grey background color */
  .container:hover input~.checkmark {
    background-color: #ccc;
  }

  /* When the checkbox is checked, add a blue background */
  .container input:checked~.checkmark {
    background-color: #2196F3;
  }

  /* Create the checkmark/indicator (hidden when not checked) */
  .checkmark:after {
    content: "";
    position: absolute;
    display: none;
  }

  /* Show the checkmark when checked */
  .container input:checked~.checkmark:after {
    display: block;
  }

  /* Style the checkmark/indicator */
  .container .checkmark:after {
    left: 9px;
    top: 5px;
    width: 5px;
    height: 10px;
    border: solid white;
    border-width: 0 3px 3px 0;
    transform: rotate(45deg);
  }
</style>