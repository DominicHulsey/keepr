<template>
  <div class="makeVault">
    <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Create New Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true"></span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="makeVault">
              <div class="input-group my-4">
                <div class="input-group-prepend">
                  <div class="input-group-text bgBlue bordR text-white">Title</div>
                </div>
                <input type="text" class="form-control" v-model="newVault.name" placeholder="Name">
              </div>
              <div class="input-group my-4">
                <div class="input-group-prepend">
                  <div class="input-group-text bgPurp bordR text-white">Description</div>
                </div>
                <input type="text" class="form-control" v-model="newVault.description" placeholder="Description">
              </div>
              <div class="modal-footer">
                <button type="button" class="btn bgBlack bordR text-white" data-dismiss="modal">Close</button>
                <button type="submit" @click="hideModal()" class="btn boardR bgPurp text-white bordR">Create
                  Vault</button>
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
    name: 'makeVault',
    data() {
      return {
        newVault: {}
      }
    },
    computed: {},
    methods: {
      makeVault() {
        let payload = {
          userId: this.$store.state.user.id,
          name: this.newVault.name,
          description: this.newVault.description
        }
        this.$store.dispatch("makeVault", payload)
      },
      hideModal() {
        $('#exampleModal2').modal('hide');
      }
    }, components: {}
  } 
</script>
<style>
  .bgPurp {
    background: #fc0095;
  }

  .bgBlue {
    background-color: #007bff;
  }

  .bordR {
    border-radius: 0 !important;
  }
</style>