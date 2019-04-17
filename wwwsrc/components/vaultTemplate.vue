<template>
  <div class="vaultTemplate">
    <drop @drop="handleDrop" class="col-11 border border-dark rounded my-2">
      <p>{{vault.name}} <button class="btn btn-outline-danger btn-sm" @click="deleteVault(vault.id)">d</button></p>
      <div class="row d-flex justify-content-around">
        <div class="m-2" v-for="keep in keeps">
          <img class="img-fluid border border-dark" :src="keep.img" id="vaultKeep" />
        </div>
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
      if (this.$store.state.keeps.length > 0) {
        this.$store.dispatch("getVaultKeeps", this.vault.id)
      }
    },
    data() {
      return {
      }
    },
    computed: {
      keeps() {
        if (this.$store.state.vaultkeeps.find(keep => keep.vaultId == this.vault.id)) {
          return this.$store.state.vaultkeeps.find(keep => keep.vaultId == this.vault.id).keeps
        }
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