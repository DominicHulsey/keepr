<template>
  <div class="vaultTemplate">
    <drop @drop="handleDrop" class="col-11 border border-dark rounded my-2">
      <p class="mt-2">{{vault.name}}</p>
      <hr>
      <div class="row d-flex justify-content-around">
        <img class="img-fluid border border-dark mb-2" v-for="keep in keeps" :src="keep.img" id="vaultKeep" />
      </div>
    </drop>
  </div>
</template>


<script>
  import { Drag, Drop } from 'vue-drag-drop';
  export default {
    name: 'vaultTemplate',
    props: ["vault", "keep"],
    mounted() {
      this.$store.dispatch("getVaultKeeps", this.vault.id)
    },
    data() {
      return {
      }
    },
    computed: {
      keeps() {
        return this.$store.state.vaultkeeps[this.vault.id]
      },
      loggedIn() {
        return this.$store.state.user.id
      }
    },
    methods: {
      handleDrop(keep) {
        let payload = {
          vaultId: this.vault.id,
          userId: this.$store.state.user.id,
          keepId: keep.id
        }
        this.$store.dispatch("addToVault", payload)
      },
      deleteVault(id) {
        this.$store.dispatch("deleteVault", id)
      },
    },
    components: {
      Drag,
      Drop,
    }
  }
</script>


<style scoped>
  #vaultKeep {
    max-height: 30px;
    width: auto;
  }
</style>