<template>
  <div class="makeVault">
    <!-- Button trigger modal -->
    <!-- Modal -->
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
                  <div class="input-group-text">Title</div>
                </div>
                <input type="text" class="form-control" v-model="newVault.name" placeholder="Name">
              </div>
              <div class="input-group my-4">
                <div class="input-group-prepend">
                  <div class="input-group-text">Description</div>
                </div>
                <input type="text" class="form-control" v-model="newVault.description" placeholder="Description">
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                <button type="submit" class="btn btn-primary">Create Vault</button>
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
      }
    }, components: {}
  } </script>
<style scoped>

</style>